using System.Runtime.InteropServices;
using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

public class MainTerminalStreamProvider : ITerminalStreamProvider
{
    private MainTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }



    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new MainTerminalStreamProvider(terminal);
    }



    public virtual Stream AcquireStandardInput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open("/dev/stdin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);}
        else
        {
            return Console.OpenStandardInput();
        }
    }

    public virtual Stream AcquireStandardOutput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open($"/dev/stdout", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        }
        else
        {
            return Console.OpenStandardOutput();
        }
    }

    public virtual Stream AcquireStandardError()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open("/dev/stderr", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        }
        else
        {
            return Console.OpenStandardError();
        }
    }
    
}