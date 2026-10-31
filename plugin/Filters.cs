using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitchWorld;

/// <summary>
/// Todas as regras de seguranca/limpeza ficam aqui:
/// sem comandos (/ e !), sem emojis, sem emotes, sem links.
/// </summary>
public static class Filters
{
    public const int MaxIncomingLength = 300;
    public const int MaxOutgoingLength = 400;

    private static readonly Regex LinkRegex = new(
        @"(?:https?:|ftp:|www\.)\S*|\b[a-z0-9-]+(?:\.[a-z0-9-]+)*\.(?:com|net|org|tv|gg|io|co|br|me|ly|app|dev|xyz|info|link|live|gl|be|to|cc|ru|de|uk|fr|pt|es|us|ai|gd|sh|click|site|online|store|top|fun|ws|tk|ml|ga|cf|gq)\b(?:/\S*)?",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex SpacesRegex = new(@"\s+", RegexOptions.Compiled);

    private static readonly HashSet<string> ReservedPaths = new(StringComparer.OrdinalIgnoreCase)
    {
        "popout", "u", "embed", "moderator", "dashboard", "directory", "videos", "settings", "chat",
    };

    // ---------- Canal ----------

    /// <summary>Extrai o nome do canal de um link da Twitch (ou aceita so o nome).</summary>
    public static string? ParseChannel(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        input = input.Trim();

        var patterns = new[]
        {
            @"twitch\.tv/popout/u/([A-Za-z0-9_]{3,25})(?:/|\?|#|$)",
            @"twitch\.tv/popout/([A-Za-z0-9_]{3,25})(?:/|\?|#|$)",
            @"twitch\.tv/embed/([A-Za-z0-9_]{3,25})(?:/|\?|#|$)",
            @"twitch\.tv/moderator/([A-Za-z0-9_]{3,25})(?:/|\?|#|$)",
            @"twitch\.tv/([A-Za-z0-9_]{3,25})(?:/|\?|#|$)",
        };

        foreach (var pattern in patterns)
        {
            var m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m.Success && !ReservedPaths.Contains(m.Groups[1].Value))
                return m.Groups[1].Value.ToLowerInvariant();
        }

        var plain = Regex.Match(input, @"^@?([A-Za-z0-9_]{3,25})$");
        if (plain.Success) return plain.Groups[1].Value.ToLowerInvariant();

        return null;
    }

    // ---------- Comandos ----------

    public static bool StartsLikeCommand(string s)
    {
        s = s.TrimStart();
        return s.StartsWith('/') || s.StartsWith('!');
    }

    // ---------- Mensagens que chegam da Twitch ----------

    /// <summary>Devolve o texto limpo, ou null se a mensagem deve ser ignorada.</summary>
    public static string? SanitizeIncoming(string raw, string? emotesTag)
    {
        var msg = raw;

        // "/me texto" chega como ACTION
        if (msg.StartsWith("\u0001ACTION ", StringComparison.Ordinal))
            msg = msg.Substring(8).TrimEnd('\u0001');

        // 1) Comandos de chat (/ ou !) sao ignorados por completo
        if (StartsLikeCommand(msg)) return null;

        // 2) Emotes oficiais da Twitch (pelas posicoes informadas) e emojis
        msg = RemoveEmotes(msg, emotesTag);
        msg = StripUnsafe(msg);

        // 3) Links
        msg = LinkRegex.Replace(msg, " ");
        msg = Collapse(msg);

        if (msg.Length == 0) return null;
        if (StartsLikeCommand(msg)) return null;

        if (msg.Length > MaxIncomingLength) msg = msg[..MaxIncomingLength] + "...";
        return msg;
    }

    public static string CleanName(string name)
    {
        var n = Collapse(StripUnsafe(name));
        if (n.Length == 0) return "?";
        return n.Length > 25 ? n[..25] : n;
    }

    // ---------- Mensagens que o jogador envia ----------

    public static bool TryPrepareOutgoing(string? raw, out string text, out string error)
    {
        text = "";
        error = "";

        var msg = Collapse(StripUnsafe(raw ?? ""));
        if (msg.Length == 0)
        {
            error = "Mensagem vazia.";
            return false;
        }

        if (StartsLikeCommand(msg))
        {
            error = "Comandos que começam com / ou ! não são permitidos.";
            return false;
        }

        if (LinkRegex.IsMatch(msg))
        {
            error = "Links não são permitidos.";
            return false;
        }

        if (msg.Length > MaxOutgoingLength) msg = msg[..MaxOutgoingLength];

        text = msg;
        return true;
    }

    // ---------- Ferramentas ----------

    private static string Collapse(string s) => SpacesRegex.Replace(s, " ").Trim();

    private static string RemoveEmotes(string message, string? emotesTag)
    {
        if (string.IsNullOrEmpty(emotesTag)) return message;

        var runes = message.EnumerateRunes().ToList();
        var remove = new bool[runes.Count];

        foreach (var emote in emotesTag.Split('/', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = emote.Split(':');
            if (parts.Length != 2) continue;

            foreach (var range in parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var se = range.Split('-');
                if (se.Length != 2) continue;
                if (!int.TryParse(se[0], out var start) || !int.TryParse(se[1], out var end)) continue;

                for (var i = Math.Max(0, start); i <= end && i < runes.Count; i++)
                    remove[i] = true;
            }
        }

        var sb = new StringBuilder(message.Length);
        for (var i = 0; i < runes.Count; i++)
            if (!remove[i])
                sb.Append(runes[i].ToString());

        return sb.ToString();
    }

    /// <summary>Remove emojis, caracteres invisiveis, de controle e simbolos especiais do jogo.</summary>
    public static string StripUnsafe(string s)
    {
        var sb = new StringBuilder(s.Length);
        foreach (var r in s.EnumerateRunes())
        {
            if (IsEmoji(r.Value)) continue;

            var cat = Rune.GetUnicodeCategory(r);
            if (cat == UnicodeCategory.Control)
            {
                sb.Append(' ');
                continue;
            }

            if (cat is UnicodeCategory.Format
                or UnicodeCategory.PrivateUse
                or UnicodeCategory.Surrogate
                or UnicodeCategory.OtherNotAssigned)
                continue;

            sb.Append(r.ToString());
        }

        return sb.ToString();
    }

    private static bool IsEmoji(int cp) =>
        cp is (>= 0x1F000 and <= 0x1FAFF)
            or (>= 0x2600 and <= 0x27BF)
            or (>= 0x2300 and <= 0x23FF)
            or (>= 0x2B00 and <= 0x2BFF)
            or (>= 0x2194 and <= 0x2199)
            or 0x21A9 or 0x21AA
            or 0x203C or 0x2049 or 0x2122 or 0x2139 or 0x24C2
            or 0x25AA or 0x25AB or 0x25B6 or 0x25C0
            or (>= 0x25FB and <= 0x25FE)
            or 0x2934 or 0x2935 or 0x3030 or 0x303D or 0x3297 or 0x3299
            or 0xA9 or 0xAE
            or (>= 0xFE00 and <= 0xFE0F)
            or 0x200D or 0x20E3
            or (>= 0xE0020 and <= 0xE007F);
}
