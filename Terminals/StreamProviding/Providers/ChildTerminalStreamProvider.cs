using System.Net;
using System.Runtime.InteropServices;
using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

public class ChildTerminalStreamProvider : ITerminalStreamProvider
{

    private ChildTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }



    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new ChildTerminalStreamProvider(terminal);
    }



    public virtual Stream AcquireStandardInput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Console.WriteLine(Terminal.ProcessId);
            
            return UnixTerminalStream.Open($"/proc/{Terminal.ProcessId}/fd/0", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }

    public virtual Stream AcquireStandardOutput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open($"/proc/{Terminal.ProcessId}/fd/1", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        }
        
        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }

    public virtual Stream AcquireStandardError()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open($"/proc/{Terminal.ProcessId}/fd/2", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        }
        
        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }
    
}