using System.IO.Pipes;
using System.Runtime.InteropServices;
using ChildTerminalGuest;
using StreamJsonRpc;
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



    public virtual TerminalStream AcquireStandardInput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Console.WriteLine(Terminal.ProcessId);
            
            return UnixTerminalStream.Open(Terminal.ProcessId, TerminalStreamType.In);
        }

        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }

    public virtual TerminalStream AcquireStandardOutput()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open(Terminal.ProcessId, TerminalStreamType.Out);
        }
        
        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }

    public virtual TerminalStream AcquireStandardError()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return UnixTerminalStream.Open(Terminal.ProcessId, TerminalStreamType.Error);
        }
        
        throw new PlatformNotSupportedException("Any platform other than Linux is currently not supported.");
    }
    
    
    public virtual async Task<TerminalCommunicationStreamClient> AcquireCommunicationStreamAsync()
    {
        // TODO Move functionality to TerminalCommunicationStreamClient
        NamedPipeClientStream communicationPipe = new NamedPipeClientStream($"ChildTerminalCommunication_{Terminal.ProcessId}");
        await communicationPipe.ConnectAsync();

        throw new NotImplementedException();
    }
}