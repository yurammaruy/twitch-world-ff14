using System;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;

namespace TwitchWorld.Windows;

/// <summary>A janela "Twitch World": o chat da Twitch dentro do jogo.</summary>
public class MainWindow : Window, IDisposable
{
    private readonly Plugin plugin;
    private string input = string.Empty;
    private string feedback = string.Empty;

    public MainWindow(Plugin plugin) : base("Twitch World###TwitchWorldMain")
    {
        this.plugin = plugin;

        Size = new Vector2(420, 320);
        SizeCondition = ImGuiCond.FirstUseEver;

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(280, 160),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue),
        };
    }

    public void Dispose() { }

    public override void Draw()
    {
        var cfg = plugin.Configuration;
        var client = plugin.Client;

        // ----- Linha de status -----
        var statusColor = client.IsConnected
            ? new Vector4(0.4f, 1f, 0.4f, 1f)
            : new Vector4(1f, 0.75f, 0.3f, 1f);
        ImGui.TextColored(statusColor, client.Status);

        if (client.IsRunning)
        {
            if (ImGui.SmallButton("Desconectar")) plugin.Disconnect();
        }
        else
        {
            if (ImGui.SmallButton("Conectar"))
            {
                if (!plugin.Connect())
                    feedback = "Configure primeiro o link do chat (botão Config).";
            }
        }

        ImGui.SameLine();
        if (ImGui.SmallButton("Config")) plugin.ToggleConfigUi();

        // ----- Area das mensagens -----
        var reserve = cfg.Interactive
            ? ImGui.GetFrameHeightWithSpacing() + ImGui.GetTextLineHeightWithSpacing()
            : ImGui.GetTextLineHeightWithSpacing();

        ImGui.BeginChild("##tw_lines", new Vector2(0, -reserve), true);

        var atBottom = ImGui.GetScrollY() >= ImGui.GetScrollMaxY() - 1f;

        lock (plugin.LinesLock)
        {
            foreach (var line in plugin.Lines)
                DrawLine(line, cfg);
        }

        if (atBottom) ImGui.SetScrollHereY(1f);

        ImGui.EndChild();

        // ----- Rodape -----
        if (cfg.Interactive)
        {
            ImGui.SetNextItemWidth(-65f * ImGuiHelpers.GlobalScale);
            var send = ImGui.InputText("##tw_input", ref input, 400, ImGuiInputTextFlags.EnterReturnsTrue);
            ImGui.SameLine();
            if (ImGui.Button("Enviar")) send = true;

            if (send)
            {
                var (ok, message) = plugin.SendToTwitch(input);
                feedback = ok ? string.Empty : message;
                if (ok) input = string.Empty;
                ImGui.SetKeyboardFocusHere(-1);
            }

            if (!string.IsNullOrEmpty(feedback))
                ImGui.TextColored(new Vector4(1f, 0.45f, 0.45f, 1f), feedback);
            else if (!string.IsNullOrEmpty(client.LastNotice))
                ImGui.TextDisabled(client.LastNotice);
            else
                ImGui.TextDisabled("Escreva e aperte Enter. Sem comandos (/ ou !), emojis ou links.");
        }
        else
        {
            if (!string.IsNullOrEmpty(feedback))
                ImGui.TextColored(new Vector4(1f, 0.45f, 0.45f, 1f), feedback);
            else
                ImGui.TextDisabled("Modo somente leitura (mude em Config).");
        }
    }

    private static void DrawLine(ChatLine line, Configuration cfg)
    {
        // horario
        ImGui.TextDisabled($"{line.Time:HH:mm}");
        ImGui.SameLine(0f, 4f);

        // selos [STREAMER] [MOD] [VIP] [SUB] [BOT]
        if (cfg.ShowBadges)
        {
            foreach (var (text, rgb) in ChatStyle.Badges(line))
            {
                ImGui.TextColored(ChatStyle.ToVec4(rgb), text);
                ImGui.SameLine(0f, 4f);
            }
        }

        // nome (na cor da Twitch)
        var nameColor = ChatStyle.ToVec4(ChatStyle.NameColor(line, cfg.ColorizeNames));
        ImGui.TextColored(nameColor, line.User + ":");
        ImGui.SameLine(0f, 4f);

        // texto (dourado se citou voce, verde-agua se for bot)
        Vector4? textColor = null;
        if (line.IsMention && cfg.HighlightMentions) textColor = ChatStyle.ToVec4(ChatStyle.MentionColor);
        else if (line.IsBot && cfg.HighlightBots) textColor = ChatStyle.ToVec4(ChatStyle.BotColor);

        if (textColor.HasValue) ImGui.PushStyleColor(ImGuiCol.Text, textColor.Value);
        ImGui.TextWrapped(line.Text);
        if (textColor.HasValue) ImGui.PopStyleColor();
    }
}
