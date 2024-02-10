using System.Runtime.InteropServices;
using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

public class NullTerminalStreamProvider : ITerminalStreamProvider
{

    private NullTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }

    
    
    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new NullTerminalStreamProvider(terminal);
    }



    public virtual TerminalStream AcquireStandardInput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Null;
        }

        throw new NotImplementedException();
    }

    public virtual TerminalStream AcquireStandardOutput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Null;
        }

        throw new NotImplementedException();
    }

    public virtual TerminalStream AcquireStandardError()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Null;
        }

        throw new NotImplementedException();
    }
    
}