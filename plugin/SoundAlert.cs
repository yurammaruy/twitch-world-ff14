using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TwitchWorld;

/// <summary>
/// Toca o som de alerta (WAV embutido no plugin) usando o winmm do Windows.
/// O som fica na memoria, entao nao depende de nenhum arquivo externo.
/// </summary>
public sealed class SoundAlert : IDisposable
{
    private const uint SND_ASYNC = 0x0001;
    private const uint SND_NODEFAULT = 0x0002;
    private const uint SND_MEMORY = 0x0004;

    [DllImport("winmm.dll", EntryPoint = "PlaySoundW", ExactSpelling = true)]
    private static extern bool PlaySound(IntPtr data, IntPtr module, uint flags);

    private readonly byte[]? wav;
    private GCHandle handle;
    private DateTime lastPlayed = DateTime.MinValue;

    public bool Available => wav != null && handle.IsAllocated;

    public SoundAlert()
    {
        try
        {
            using var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("TwitchWorld.Sounds.alert.wav");
            if (stream == null) return;

            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            wav = ms.ToArray();
            handle = GCHandle.Alloc(wav, GCHandleType.Pinned);
        }
        catch
        {
            wav = null;
        }
    }

    /// <summary>Toca o alerta. Alertas seguidos (menos de 1,5 s) sao ignorados, a menos que ignoreInterval.</summary>
    public void Play(bool ignoreInterval = false)
    {
        if (!Available) return;

        var now = DateTime.UtcNow;
        if (!ignoreInterval && (now - lastPlayed).TotalMilliseconds < 1500) return;
        lastPlayed = now;

        try
        {
            PlaySound(handle.AddrOfPinnedObject(), IntPtr.Zero, SND_MEMORY | SND_ASYNC | SND_NODEFAULT);
        }
        catch
        {
            // Sem audio disponivel: ignora.
        }
    }

    public void Dispose()
    {
        try
        {
            PlaySound(IntPtr.Zero, IntPtr.Zero, 0);
        }
        catch
        {
            // ignora
        }

        if (handle.IsAllocated) handle.Free();
    }
}
