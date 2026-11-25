using System;
using System.Collections.Generic;
using System.Numerics;
using Lumina.Excel.Sheets;

namespace TwitchWorld;

/// <summary>Cores e selos das mensagens (usado pela janela e pelo chat do jogo).</summary>
public static class ChatStyle
{
    public const uint OwnColor = 0x7FC8FF;      // suas proprias mensagens
    public const uint BotColor = 0x6FD6C8;      // bots
    public const uint MentionColor = 0xFFD84D;  // mensagens que citam voce
    public const uint PlainNameColor = 0xC9A7FF; // quando "usar a cor de cada usuario" esta desligado

    // Cores para quem nunca escolheu uma cor na Twitch (todas claras, boas para fundo escuro)
    private static readonly uint[] Palette =
    {
        0xFF6B6B, 0xFFA94D, 0xFFD43B, 0x94D82D, 0x38D9A9, 0x3BC9DB,
        0x4DABF7, 0x748FFC, 0xB197FC, 0xE599F7, 0xF783AC, 0xFF8787,
    };

    /// <summary>Cor de cada tipo de alerta (RAID, INSCRICAO, PRESENTE, BITS...).</summary>
    public static uint AlertColor(string label) => label switch
    {
        "RAID" => 0xFF8A4D,
        "INSCRIÇÃO" => 0xB197FC,
        "PRESENTE" => 0xF783AC,
        "BITS" => 0x4DABF7,
        "RESGATE" => 0x94D82D,
        "NOVO NO CHAT" => 0x38D9A9,
        _ => 0xFFD43B,
    };

    public static uint NameColor(ChatLine line, bool colorize)
    {
        if (!colorize) return PlainNameColor;
        if (line.IsMine) return OwnColor;
        if (line.IsBot) return BotColor;
        if (line.Rgb != 0) return Readable(line.Rgb);
        return Fallback(line.Login.Length > 0 ? line.Login : line.User);
    }

    /// <summary>Clareia cores escuras (azul escuro, preto...) para dar para ler no fundo escuro.</summary>
    public static uint Readable(uint rgb)
    {
        var r = (int)((rgb >> 16) & 0xFF);
        var g = (int)((rgb >> 8) & 0xFF);
        var b = (int)(rgb & 0xFF);

        var brightness = (0.299 * r + 0.587 * g + 0.114 * b) / 255.0;
        const double target = 0.62;
        if (brightness >= target) return rgb;

        var t = (target - brightness) / (1.0 - brightness);
        r = (int)(r + (255 - r) * t);
        g = (int)(g + (255 - g) * t);
        b = (int)(b + (255 - b) * t);
        return (uint)((r << 16) | (g << 8) | b);
    }

    private static uint Fallback(string key)
    {
        var hash = 17;
        foreach (var ch in key) hash = unchecked(hash * 31 + ch);
        return Palette[(hash & 0x7FFFFFFF) % Palette.Length];
    }

    public static List<(string Text, uint Rgb)> Badges(ChatLine line)
    {
        var list = new List<(string, uint)>(4);
        if (line.Roles.HasFlag(Roles.Broadcaster)) list.Add(("[STREAMER]", 0xFF6B6B));
        if (line.Roles.HasFlag(Roles.Moderator)) list.Add(("[MOD]", 0x5CD65C));
        if (line.Roles.HasFlag(Roles.Vip)) list.Add(("[VIP]", 0xFF7AD9));
        if (line.Roles.HasFlag(Roles.Subscriber)) list.Add(("[SUB]", 0xA78BFA));
        if (line.IsBot) list.Add(("[BOT]", BotColor));
        return list;
    }

    public static Vector4 ToVec4(uint rgb) => new(
        ((rgb >> 16) & 0xFF) / 255f,
        ((rgb >> 8) & 0xFF) / 255f,
        (rgb & 0xFF) / 255f,
        1f);
}

/// <summary>
/// O chat do jogo so aceita cores da tabela interna do FFXIV (UIColor).
/// Aqui achamos, nessa tabela, a cor mais parecida com a cor desejada.
/// </summary>
public static class GameColors
{
    private static readonly object Gate = new();
    private static List<(ushort Key, int R, int G, int B)>? palette;
    private static readonly Dictionary<uint, ushort> Cache = new();

    /// <summary>Devolve o codigo de cor do jogo mais proximo, ou 0 se nao foi possivel (sem cor).</summary>
    public static ushort Nearest(uint rgb)
    {
        lock (Gate)
        {
            if (Cache.TryGetValue(rgb, out var cached)) return cached;

            palette ??= Build();

            var r = (int)((rgb >> 16) & 0xFF);
            var g = (int)((rgb >> 8) & 0xFF);
            var b = (int)(rgb & 0xFF);

            ushort best = 0;
            var bestDistance = long.MaxValue;

            foreach (var (key, pr, pg, pb) in palette)
            {
                long dr = pr - r, dg = pg - g, db = pb - b;
                var distance = dr * dr + dg * dg + db * db;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    best = key;
                }
            }

            Cache[rgb] = best;
            return best;
        }
    }

    private static List<(ushort Key, int R, int G, int B)> Build()
    {
        var list = new List<(ushort, int, int, int)>();

        try
        {
            var sheet = Plugin.DataManager.GetExcelSheet<UIColor>();
            foreach (var row in sheet)
            {
                if (row.RowId == 0 || row.RowId > ushort.MaxValue) continue;

                var value = row.Dark; // formato RRGGBBAA
                if ((value & 0xFF) != 0xFF) continue;

                var r = (int)((value >> 24) & 0xFF);
                var g = (int)((value >> 16) & 0xFF);
                var b = (int)((value >> 8) & 0xFF);

                if (r + g + b < 300) continue; // ignora cores escuras demais para ler no chat

                list.Add(((ushort)row.RowId, r, g, b));
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.Warning(ex, "Nao foi possivel carregar a tabela de cores do jogo.");
        }

        return list;
    }
}
