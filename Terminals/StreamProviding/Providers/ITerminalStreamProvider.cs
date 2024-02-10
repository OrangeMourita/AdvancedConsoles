using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

public interface ITerminalStreamProvider
{
    Terminal Terminal { get; set; }
    
    void AcquireStandardStreams()
    {
        Terminal.StandardInput = AcquireStandardInput();
        Terminal.StandardOutput = AcquireStandardOutput();
        Terminal.StandardError = AcquireStandardError();
    }
    
    TerminalStream AcquireStandardInput();
    TerminalStream AcquireStandardOutput();
    TerminalStream AcquireStandardError();
}