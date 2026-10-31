using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Dalamud.Game.Command;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using TwitchWorld.Windows;

namespace TwitchWorld;

public sealed class Plugin : IDalamudPlugin
{
    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;
    [PluginService] internal static IChatGui ChatGui { get; private set; } = null!;
    [PluginService] internal static IFramework FrameworkService { get; private set; } = null!;
    [PluginService] internal static IPlayerState PlayerState { get; private set; } = null!;
    [PluginService] internal static IDataManager DataManager { get; private set; } = null!;
    [PluginService] internal static IPluginLog Log { get; private set; } = null!;

    private const string CommandName = "/tw-chat";
    private const int MaxLines = 300;

    public Configuration Configuration { get; }
    public TwitchClient Client { get; } = new();

    // Mensagens ja prontas para exibir na janela
    public readonly List<ChatLine> Lines = new();
    public readonly object LinesLock = new();

    // Fila entre a internet (outra thread) e o jogo (thread principal)
    private readonly ConcurrentQueue<ChatLine> incoming = new();

    // Cache da lista de bots (so reconstroi quando o texto muda)
    private string botKey = "\u0000";
    private HashSet<string> botSet = new();

    public readonly WindowSystem WindowSystem = new("TwitchWorld");
    private readonly MainWindow mainWindow;
    private readonly ConfigWindow configWindow;

    public Plugin()
    {
        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

        mainWindow = new MainWindow(this);
        configWindow = new ConfigWindow(this);
        WindowSystem.AddWindow(mainWindow);
        WindowSystem.AddWindow(configWindow);

        Client.MessageReceived += OnTwitchMessage;
        FrameworkService.Update += OnFrameworkUpdate;

        CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Abre a janela Twitch World. Use /tw-chat sua mensagem para enviar ao chat da Twitch.",
            ShowInHelp = true,
        });

        PluginInterface.UiBuilder.Draw += WindowSystem.Draw;
        PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUi;
        PluginInterface.UiBuilder.OpenMainUi += ToggleMainUi;

        if (Configuration.AutoConnect)
            Connect();
    }

    public void Dispose()
    {
        PluginInterface.UiBuilder.Draw -= WindowSystem.Draw;
        PluginInterface.UiBuilder.OpenConfigUi -= ToggleConfigUi;
        PluginInterface.UiBuilder.OpenMainUi -= ToggleMainUi;

        FrameworkService.Update -= OnFrameworkUpdate;
        Client.MessageReceived -= OnTwitchMessage;
        Client.Dispose();

        CommandManager.RemoveHandler(CommandName);
        WindowSystem.RemoveAllWindows();
    }

    public void ToggleMainUi() => mainWindow.Toggle();
    public void ToggleConfigUi() => configWindow.Toggle();

    // ---------- Conexao ----------

    /// <summary>Conecta ao canal configurado. Sempre fecha o chat anterior (so existe 1 por vez).</summary>
    public bool Connect()
    {
        var channel = Filters.ParseChannel(Configuration.ChannelLink);
        if (channel == null) return false;

        if (!string.Equals(channel, Client.CurrentChannel, StringComparison.OrdinalIgnoreCase))
        {
            lock (LinesLock) Lines.Clear();
        }

        Client.Connect(channel, Configuration.TwitchLogin, Configuration.OAuthToken, Configuration.Interactive);
        return true;
    }

    public void Disconnect() => Client.Disconnect();

    // ---------- Mensagens recebidas ----------

    private void OnTwitchMessage(ChatLine line)
    {
        // chamado em outra thread: so coloca na fila
        if (incoming.Count < 500) incoming.Enqueue(line);
    }

    private void OnFrameworkUpdate(IFramework framework)
    {
        var processed = 0;
        while (processed < 50 && incoming.TryDequeue(out var raw))
        {
            processed++;

            var line = Classify(raw);
            AddLine(line);

            if (Configuration.EchoToGameChat)
                EchoToGame(PlayerName(), BuildGameMessage(line));
        }
    }

    private void AddLine(ChatLine line)
    {
        lock (LinesLock)
        {
            Lines.Add(line);
            if (Lines.Count > MaxLines)
                Lines.RemoveRange(0, Lines.Count - MaxLines);
        }
    }

    // ---------- Bots e mencoes ----------

    private static HashSet<string> SplitNames(string? text)
    {
        var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (string.IsNullOrWhiteSpace(text)) return set;

        foreach (var part in text.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var name = part.Trim().TrimStart('@');
            if (name.Length >= 3) set.Add(name);
        }

        return set;
    }

    private HashSet<string> BotSet()
    {
        var key = Configuration.BotNames ?? "";
        if (!string.Equals(key, botKey, StringComparison.Ordinal))
        {
            botSet = SplitNames(key);
            botKey = key;
        }

        return botSet;
    }

    private HashSet<string> MentionNames()
    {
        var names = SplitNames(Configuration.ExtraHighlightNames);

        // seu usuario da Twitch; se nao preencheu, o nome do canal que voce esta lendo
        var own = Configuration.TwitchLogin;
        if (string.IsNullOrWhiteSpace(own)) own = Client.CurrentChannel;
        if (!string.IsNullOrWhiteSpace(own) && own.Length >= 3) names.Add(own.Trim().TrimStart('@'));

        return names;
    }

    private ChatLine Classify(ChatLine line)
    {
        if (line.IsMine) return line;

        var isBot = line.Login.Length > 0 && BotSet().Contains(line.Login);

        var isMention = false;
        if (!isBot)
        {
            foreach (var name in MentionNames())
            {
                if (string.Equals(name, line.Login, StringComparison.OrdinalIgnoreCase)) continue; // proprio autor
                if (line.Text.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    isMention = true;
                    break;
                }
            }
        }

        return line with { IsBot = isBot, IsMention = isMention };
    }

    // ---------- Chat do jogo ----------

    private string PlayerName()
    {
        try
        {
            if (PlayerState.IsLoaded && !string.IsNullOrWhiteSpace(PlayerState.CharacterName))
                return PlayerState.CharacterName;
        }
        catch
        {
            // ignorar
        }

        return "Você";
    }

    /// <summary>Canais do chat do jogo que podem ser usados para mostrar o chat da Twitch.</summary>
    public static readonly (XivChatType Type, string Label)[] ChatChannels =
    {
        (XivChatType.Ls8, "Linkshell [8] (recomendado)"),
        (XivChatType.CrossLinkShell8, "Cross-world Linkshell [8]"),
        (XivChatType.Echo, "Echo (sem nome na frente)"),
        (XivChatType.Say, "Falar (/say)"),
    };

    /// <summary>
    /// Monta a mensagem colorida: [SELOS] Nome disse: texto
    /// As cores sao aproximadas para a paleta do jogo.
    /// </summary>
    private SeString BuildGameMessage(ChatLine line)
    {
        var cfg = Configuration;
        var b = new SeStringBuilder();

        if (cfg.ShowBadges)
        {
            foreach (var (text, rgb) in ChatStyle.Badges(line))
            {
                var key = GameColors.Nearest(rgb);
                if (key != 0) b.AddUiForeground(text + " ", key);
                else b.AddText(text + " ");
            }
        }

        var nameKey = GameColors.Nearest(ChatStyle.NameColor(line, cfg.ColorizeNames));
        if (nameKey != 0) b.AddUiForeground(line.User, nameKey);
        else b.AddText(line.User);

        b.AddText(" disse: ");

        ushort textKey = 0;
        if (line.IsMention && cfg.HighlightMentions) textKey = GameColors.Nearest(ChatStyle.MentionColor);
        else if (line.IsBot && cfg.HighlightBots) textKey = GameColors.Nearest(ChatStyle.BotColor);

        if (textKey != 0) b.AddUiForeground(line.Text, textKey);
        else b.AddText(line.Text);

        return b.Build();
    }

    private void EchoToGame(string name, SeString message)
    {
        // Aparece SO para voce, no chat do jogo. Ninguem mais ve.
        var index = Math.Clamp(Configuration.GameChatChannel, 0, ChatChannels.Length - 1);
        ChatGui.Print(new XivChatEntry
        {
            Type = ChatChannels[index].Type,
            Name = name,
            Message = message,
        });
    }

    // ---------- Envio para a Twitch ----------

    /// <summary>Envia uma mensagem do jogador para o chat da Twitch (mesmas regras de filtro).</summary>
    public (bool Ok, string Message) SendToTwitch(string raw)
    {
        if (!Configuration.Interactive)
            return (false, "Você está no modo somente leitura. Ative \"ler e enviar\" nas configurações.");

        if (!Filters.TryPrepareOutgoing(raw, out var text, out var error))
            return (false, error);

        if (!Client.TrySend(text, out error))
            return (false, error);

        var me = string.IsNullOrWhiteSpace(Configuration.TwitchLogin) ? "você" : Configuration.TwitchLogin;
        AddLine(new ChatLine(DateTime.Now, me, text, true));

        if (Configuration.EchoToGameChat)
            EchoToGame(PlayerName(), new SeStringBuilder().AddText(text).Build());

        return (true, "");
    }

    // ---------- Comando /tw-chat ----------

    private void OnCommand(string command, string args)
    {
        if (string.IsNullOrWhiteSpace(args))
        {
            mainWindow.IsOpen = true;
            ChatGui.Print("Janela aberta. Para enviar algo à Twitch use: /tw-chat sua mensagem", "Twitch World");
            return;
        }

        var (ok, message) = SendToTwitch(args);
        if (!ok)
            ChatGui.PrintError(message, "Twitch World");
    }
}
