using System;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace TwitchWorld.Windows;

public class ConfigWindow : Window, IDisposable
{
    private readonly Plugin plugin;

    private string link;
    private string login;
    private string token;
    private string botNames;
    private string extraNames;

    public ConfigWindow(Plugin plugin) : base("Twitch World - Configurações###TwitchWorldConfig")
    {
        this.plugin = plugin;

        Size = new Vector2(500, 640);
        SizeCondition = ImGuiCond.FirstUseEver;

        link = plugin.Configuration.ChannelLink;
        login = plugin.Configuration.TwitchLogin;
        token = plugin.Configuration.OAuthToken;
        botNames = plugin.Configuration.BotNames;
        extraNames = plugin.Configuration.ExtraHighlightNames;
    }

    public void Dispose() { }

    public override void Draw()
    {
        var cfg = plugin.Configuration;

        // ----- 1. Canal -----
        ImGui.TextUnformatted("1) Link do chat (ou só o nome do canal)");
        ImGui.SetNextItemWidth(-1f);
        if (ImGui.InputText("##link", ref link, 300))
        {
            cfg.ChannelLink = link;
        }

        if (ImGui.IsItemDeactivatedAfterEdit()) cfg.Save();

        var channel = Filters.ParseChannel(cfg.ChannelLink);
        if (channel != null)
            ImGui.TextColored(new Vector4(0.4f, 1f, 0.4f, 1f), $"Canal reconhecido: {channel}");
        else
            ImGui.TextColored(new Vector4(1f, 0.6f, 0.3f, 1f), "Ainda não consegui reconhecer o canal.");

        ImGui.Separator();

        // ----- 2. Modo -----
        ImGui.TextUnformatted("2) O que você quer fazer?");

        var readOnly = !cfg.Interactive;
        if (ImGui.RadioButton("Só ler as mensagens do chat", readOnly))
        {
            if (cfg.Interactive)
            {
                cfg.Interactive = false;
                cfg.Save();
                if (plugin.Client.IsRunning) plugin.Connect();
            }
        }

        if (ImGui.RadioButton("Ler e também enviar mensagens (/tw-chat)", !readOnly))
        {
            if (!cfg.Interactive)
            {
                cfg.Interactive = true;
                cfg.Save();
                if (plugin.Client.IsRunning) plugin.Connect();
            }
        }

        // ----- 3. Conta (so se for enviar) -----
        if (cfg.Interactive)
        {
            ImGui.Separator();
            ImGui.TextUnformatted("3) Sua conta da Twitch (necessária para enviar)");

            ImGui.TextUnformatted("Seu nome de usuário da Twitch");
            ImGui.SetNextItemWidth(-1f);
            if (ImGui.InputText("##login", ref login, 40)) cfg.TwitchLogin = login;
            if (ImGui.IsItemDeactivatedAfterEdit()) cfg.Save();

            ImGui.TextUnformatted("Token de acesso (funciona como uma senha, não mostre a ninguém)");
            ImGui.SetNextItemWidth(-1f);
            if (ImGui.InputText("##token", ref token, 100, ImGuiInputTextFlags.Password)) cfg.OAuthToken = token;
            if (ImGui.IsItemDeactivatedAfterEdit())
            {
                cfg.Save();
                if (plugin.Client.IsRunning) plugin.Connect();
            }

            ImGui.TextDisabled("Veja o arquivo LEIA-ME para gerar o token (permissões: chat:read e chat:edit).");
        }

        ImGui.Separator();

        // ----- Extras -----
        var auto = cfg.AutoConnect;
        if (ImGui.Checkbox("Conectar automaticamente ao abrir o jogo", ref auto))
        {
            cfg.AutoConnect = auto;
            cfg.Save();
        }

        var echo = cfg.EchoToGameChat;
        if (ImGui.Checkbox("Mostrar as mensagens no chat do jogo (só você vê)", ref echo))
        {
            cfg.EchoToGameChat = echo;
            cfg.Save();
        }

        if (cfg.EchoToGameChat)
        {
            var current = Math.Clamp(cfg.GameChatChannel, 0, Plugin.ChatChannels.Length - 1);
            ImGui.TextUnformatted("Canal usado no chat do jogo:");
            ImGui.SetNextItemWidth(-1f);
            if (ImGui.BeginCombo("##canal", Plugin.ChatChannels[current].Label))
            {
                for (var i = 0; i < Plugin.ChatChannels.Length; i++)
                {
                    if (ImGui.Selectable(Plugin.ChatChannels[i].Label, i == current))
                    {
                        cfg.GameChatChannel = i;
                        cfg.Save();
                    }
                }

                ImGui.EndCombo();
            }

            ImGui.TextDisabled("Depois, no jogo, deixe esse canal marcado só na sua aba \"Twitch\"");
            ImGui.TextDisabled("(Configurações do Personagem > Janela de Log > Filtros de Log).");
        }

        ImGui.Separator();

        // ----- Filtro e cores -----
        ImGui.TextUnformatted("Cores e destaques do chat");

        var colorize = cfg.ColorizeNames;
        if (ImGui.Checkbox("Usar a cor que cada pessoa escolheu na Twitch", ref colorize))
        {
            cfg.ColorizeNames = colorize;
            cfg.Save();
        }

        var badges = cfg.ShowBadges;
        if (ImGui.Checkbox("Mostrar selos [STREAMER] [MOD] [VIP] [SUB] [BOT] antes do nome", ref badges))
        {
            cfg.ShowBadges = badges;
            cfg.Save();
        }

        var mentions = cfg.HighlightMentions;
        if (ImGui.Checkbox("Destacar em dourado as mensagens que citam você", ref mentions))
        {
            cfg.HighlightMentions = mentions;
            cfg.Save();
        }

        ImGui.TextUnformatted("Outros nomes para destacar (separados por vírgula)");
        ImGui.SetNextItemWidth(-1f);
        if (ImGui.InputText("##extra", ref extraNames, 200)) cfg.ExtraHighlightNames = extraNames;
        if (ImGui.IsItemDeactivatedAfterEdit()) cfg.Save();
        ImGui.TextDisabled("Seu usuário da Twitch já é destacado. Sem usuário, vale o nome do canal.");

        var bots = cfg.HighlightBots;
        if (ImGui.Checkbox("Destacar mensagens de bots (avisos de seguidor, raid...)", ref bots))
        {
            cfg.HighlightBots = bots;
            cfg.Save();
        }

        ImGui.TextUnformatted("Nomes dos bots (separados por vírgula)");
        ImGui.SetNextItemWidth(-1f);
        if (ImGui.InputText("##bots", ref botNames, 300)) cfg.BotNames = botNames;
        if (ImGui.IsItemDeactivatedAfterEdit()) cfg.Save();

        ImGui.Separator();

        if (ImGui.Button(plugin.Client.IsRunning ? "Reconectar" : "Conectar agora"))
        {
            cfg.Save();
            plugin.Connect();
        }

        ImGui.SameLine();
        if (ImGui.Button("Desconectar")) plugin.Disconnect();

        ImGui.TextWrapped(plugin.Client.Status);

        ImGui.Separator();
        ImGui.TextDisabled("Regras fixas do plugin: ignora mensagens que começam com / ou !, remove emojis, emotes e links,");
        ImGui.TextDisabled("e só mantém UM chat conectado por vez.");
    }
}
