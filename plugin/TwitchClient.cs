using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchWorld;

[Flags]
public enum Roles
{
    None = 0,
    Broadcaster = 1,
    Moderator = 2,
    Vip = 4,
    Subscriber = 8,
}

/// <summary>
/// Uma mensagem do chat. Login = nome da conta (minusculo), Rgb = cor escolhida na Twitch (0 = nenhuma).
/// IsBot e IsMention sao preenchidos pelo plugin depois de receber a mensagem.
/// </summary>
public sealed record ChatLine(
    DateTime Time,
    string User,
    string Text,
    bool IsMine,
    string Login = "",
    uint Rgb = 0,
    Roles Roles = Roles.None,
    bool IsBot = false,
    bool IsMention = false);

/// <summary>
/// Conexao com o chat da Twitch (IRC sobre WebSocket).
/// Garante que existe NO MAXIMO UMA conexao por vez: conectar de novo
/// sempre derruba a anterior antes.
/// </summary>
public sealed class TwitchClient : IDisposable
{
    private const string Endpoint = "wss://irc-ws.chat.twitch.tv:443";

    private readonly object gate = new();
    private readonly SemaphoreSlim sendLock = new(1, 1);

    private CancellationTokenSource? cts;
    private Task? runTask;
    private ClientWebSocket? socket;
    private DateTime lastSendUtc = DateTime.MinValue;

    private volatile string status = "Desconectado";
    private volatile string lastNotice = "";
    private volatile bool isConnected;
    private volatile bool canSend;
    private volatile string currentChannel = "";

    public event Action<ChatLine>? MessageReceived;

    public string Status => status;
    public string LastNotice => lastNotice;
    public bool IsConnected => isConnected;
    public bool CanSend => canSend;
    public string CurrentChannel => currentChannel;

    public bool IsRunning
    {
        get
        {
            lock (gate)
                return cts != null && !cts.IsCancellationRequested;
        }
    }

    /// <summary>Conecta a um canal. Qualquer conexao anterior e encerrada primeiro.</summary>
    public void Connect(string channel, string? login, string? token, bool wantSend)
    {
        lock (gate)
        {
            var previous = runTask;
            StopInternal();

            var run = new CancellationTokenSource();
            cts = run;

            var useAuth = wantSend
                          && !string.IsNullOrWhiteSpace(login)
                          && !string.IsNullOrWhiteSpace(token);

            string? cleanLogin = useAuth ? login!.Trim().ToLowerInvariant() : null;
            string? cleanToken = null;
            if (useAuth)
            {
                cleanToken = token!.Trim();
                if (cleanToken.StartsWith("oauth:", StringComparison.OrdinalIgnoreCase))
                    cleanToken = cleanToken.Substring(6);
            }

            var ch = channel.Trim().ToLowerInvariant();
            currentChannel = ch;
            canSend = useAuth;
            isConnected = false;
            status = $"Conectando a #{ch}...";
            lastNotice = "";

            runTask = Task.Run(() => RunAsync(previous, ch, cleanLogin, cleanToken, run));
        }
    }

    public void Disconnect()
    {
        lock (gate)
        {
            StopInternal();
            status = "Desconectado";
        }
    }

    private void StopInternal()
    {
        try { cts?.Cancel(); } catch { /* ignorar */ }
        try { socket?.Abort(); } catch { /* ignorar */ }
        socket = null;
        isConnected = false;
        canSend = false;
    }

    public void Dispose()
    {
        Disconnect();
    }

    // ---------- Envio ----------

    public bool TrySend(string text, out string error)
    {
        error = "";

        if (!isConnected)
        {
            error = "Você não está conectado ao chat da Twitch.";
            return false;
        }

        if (!canSend)
        {
            error = "Para enviar mensagens é preciso preencher usuário e token nas configurações.";
            return false;
        }

        ClientWebSocket? ws;
        lock (gate) ws = socket;

        if (ws == null || ws.State != WebSocketState.Open)
        {
            error = "Conexão indisponível no momento.";
            return false;
        }

        var now = DateTime.UtcNow;
        if ((now - lastSendUtc).TotalMilliseconds < 1500)
        {
            error = "Calma! Espere um instante entre uma mensagem e outra.";
            return false;
        }

        lastSendUtc = now;
        var channel = currentChannel;

        _ = Task.Run(async () =>
        {
            try
            {
                using var timeout = new CancellationTokenSource(5000);
                await SendRaw(ws, $"PRIVMSG #{channel} :{text}", timeout.Token);
            }
            catch
            {
                // se falhar, a reconexao automatica cuida do resto
            }
        });

        return true;
    }

    private async Task SendRaw(ClientWebSocket ws, string line, CancellationToken ct)
    {
        if (line.Contains('\r') || line.Contains('\n')) return; // protecao contra injecao de comandos IRC

        var bytes = Encoding.UTF8.GetBytes(line + "\r\n");
        await sendLock.WaitAsync(ct);
        try
        {
            await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, ct);
        }
        finally
        {
            sendLock.Release();
        }
    }

    // ---------- Loop principal ----------

    private void SetStatus(string text, bool connected, CancellationToken ct)
    {
        if (ct.IsCancellationRequested) return;
        status = text;
        isConnected = connected;
    }

    private async Task RunAsync(Task? previous, string channel, string? login, string? token, CancellationTokenSource run)
    {
        var ct = run.Token;

        // espera a conexao anterior terminar de fechar (garante 1 chat por vez)
        if (previous != null)
        {
            try { await Task.WhenAny(previous, Task.Delay(3000, ct)); }
            catch { /* ignorar */ }
        }

        var attempt = 0;
        while (!ct.IsCancellationRequested)
        {
            using var ws = new ClientWebSocket();
            try
            {
                SetStatus($"Conectando a #{channel}...", false, ct);
                await ws.ConnectAsync(new Uri(Endpoint), ct);

                lock (gate)
                {
                    if (!ct.IsCancellationRequested) socket = ws;
                }

                await SendRaw(ws, "CAP REQ :twitch.tv/tags twitch.tv/commands", ct);

                if (login != null && token != null)
                {
                    await SendRaw(ws, "PASS oauth:" + token, ct);
                    await SendRaw(ws, "NICK " + login, ct);
                }
                else
                {
                    // leitura anonima, sem conta
                    await SendRaw(ws, "PASS SCHMOOPIIE", ct);
                    await SendRaw(ws, "NICK justinfan" + Random.Shared.Next(10000, 99999), ct);
                }

                await SendRaw(ws, "JOIN #" + channel, ct);
                await ReadLoop(ws, channel, login, run);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                SetStatus("Erro de conexão: " + ex.Message, false, ct);
            }
            finally
            {
                lock (gate)
                {
                    if (ReferenceEquals(socket, ws)) socket = null;
                }
            }

            if (ct.IsCancellationRequested) break;

            attempt++;
            SetStatus($"Reconectando em 5s (tentativa {attempt})...", false, ct);
            try { await Task.Delay(5000, ct); }
            catch (OperationCanceledException) { break; }
        }
    }

    private async Task ReadLoop(ClientWebSocket ws, string channel, string? login, CancellationTokenSource run)
    {
        var ct = run.Token;
        var buffer = new byte[8192];

        while (!ct.IsCancellationRequested && ws.State == WebSocketState.Open)
        {
            using var ms = new MemoryStream();
            WebSocketReceiveResult result;
            do
            {
                result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), ct);
                if (result.MessageType == WebSocketMessageType.Close) return;

                ms.Write(buffer, 0, result.Count);
                if (ms.Length > 65536) return; // mensagem absurdamente grande: reconecta
            } while (!result.EndOfMessage);

            var text = Encoding.UTF8.GetString(ms.ToArray());
            foreach (var line in text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
                await HandleLineAsync(ws, line, channel, login, run);
        }
    }

    // ---------- Interpretacao das linhas IRC ----------

    private async Task HandleLineAsync(ClientWebSocket ws, string line, string channel, string? login, CancellationTokenSource run)
    {
        var ct = run.Token;
        var tags = new Dictionary<string, string>();
        var rest = line;

        if (rest.StartsWith('@'))
        {
            var sp = rest.IndexOf(' ');
            if (sp < 0) return;
            tags = ParseTags(rest[1..sp]);
            rest = rest[(sp + 1)..];
        }

        if (rest.StartsWith("PING", StringComparison.Ordinal))
        {
            await SendRaw(ws, "PONG :tmi.twitch.tv", ct);
            return;
        }

        var prefix = "";
        if (rest.StartsWith(':'))
        {
            var sp = rest.IndexOf(' ');
            if (sp < 0) return;
            prefix = rest[1..sp];
            rest = rest[(sp + 1)..];
        }

        var cmdEnd = rest.IndexOf(' ');
        var command = cmdEnd < 0 ? rest : rest[..cmdEnd];
        var args = cmdEnd < 0 ? "" : rest[(cmdEnd + 1)..];

        switch (command)
        {
            case "JOIN":
            case "366":
            case "ROOMSTATE":
                SetStatus(
                    $"Conectado a #{channel}" + (login != null ? $" como {login}" : " (somente leitura)"),
                    true, ct);
                break;

            case "NOTICE":
                HandleNotice(args, run);
                break;

            case "PRIVMSG":
                HandlePrivMsg(prefix, args, tags);
                break;

            case "RECONNECT":
                try { ws.Abort(); } catch { /* o loop reconecta */ }
                break;
        }
    }

    private void HandleNotice(string args, CancellationTokenSource run)
    {
        var idx = args.IndexOf(" :", StringComparison.Ordinal);
        var text = idx >= 0 ? args[(idx + 2)..] : args;

        if (text.Contains("authentication failed", StringComparison.OrdinalIgnoreCase)
            || text.Contains("Improperly formatted auth", StringComparison.OrdinalIgnoreCase)
            || text.Contains("Login unsuccessful", StringComparison.OrdinalIgnoreCase))
        {
            SetStatus("Falha no login da Twitch: confira o usuário e o token.", false, run.Token);
            canSend = false;
            try { run.Cancel(); } catch { /* ignorar */ }
            return;
        }

        lastNotice = Filters.StripUnsafe(text.Length > 120 ? text[..120] : text).Trim();
    }

    private void HandlePrivMsg(string prefix, string args, Dictionary<string, string> tags)
    {
        var idx = args.IndexOf(" :", StringComparison.Ordinal);
        if (idx < 0) return;

        var raw = args[(idx + 2)..];
        var bang = prefix.IndexOf('!');
        var nick = bang > 0 ? prefix[..bang] : prefix;

        tags.TryGetValue("display-name", out var display);
        var user = Filters.CleanName(string.IsNullOrWhiteSpace(display) ? nick : display.Replace("\\s", " "));

        tags.TryGetValue("emotes", out var emotes);
        var clean = Filters.SanitizeIncoming(raw, emotes);
        if (clean == null) return;

        // ----- selos (cargos) -----
        var roles = Roles.None;
        if (tags.TryGetValue("badges", out var badges) && !string.IsNullOrEmpty(badges))
        {
            foreach (var badge in badges.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                switch (badge.Split('/')[0])
                {
                    case "broadcaster": roles |= Roles.Broadcaster; break;
                    case "moderator": roles |= Roles.Moderator; break;
                    case "vip": roles |= Roles.Vip; break;
                    case "subscriber":
                    case "founder": roles |= Roles.Subscriber; break;
                }
            }
        }

        if (tags.TryGetValue("mod", out var mod) && mod == "1") roles |= Roles.Moderator;
        if (tags.TryGetValue("subscriber", out var sub) && sub == "1") roles |= Roles.Subscriber;

        // ----- cor escolhida pelo usuario na Twitch (ex: #FF4500) -----
        uint rgb = 0;
        if (tags.TryGetValue("color", out var color)
            && color.Length == 7 && color[0] == '#'
            && uint.TryParse(color.AsSpan(1), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var parsed))
        {
            rgb = parsed;
        }

        MessageReceived?.Invoke(new ChatLine(
            DateTime.Now, user, clean, false, nick.ToLowerInvariant(), rgb, roles));
    }

    private static Dictionary<string, string> ParseTags(string tagString)
    {
        var d = new Dictionary<string, string>();
        foreach (var kv in tagString.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            var i = kv.IndexOf('=');
            if (i > 0) d[kv[..i]] = kv[(i + 1)..];
        }

        return d;
    }
}
