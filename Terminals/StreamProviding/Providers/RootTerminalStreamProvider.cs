using System.Runtime.InteropServices;
using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

public class RootTerminalStreamProvider : ITerminalStreamProvider
{
    private RootTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }



    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new RootTerminalStreamProvider(terminal);
    }



    public virtual TerminalStream AcquireStandardInput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open(TerminalStreamType.In);
        }
        else
        {
            throw new PlatformNotSupportedException();
            // return Console.OpenStandardInput();
        }
    }

    public virtual TerminalStream AcquireStandardOutput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open(TerminalStreamType.Out);
        }
        else
        {
            throw new PlatformNotSupportedException();
            // return Console.OpenStandardOutput();
        }
    }

    public virtual TerminalStream AcquireStandardError()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open(TerminalStreamType.Error);
        }
        else
        {
            throw new PlatformNotSupportedException();
            // return Console.OpenStandardError();
        }
    }
    
}