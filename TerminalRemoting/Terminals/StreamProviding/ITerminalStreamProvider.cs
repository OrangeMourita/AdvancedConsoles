namespace TerminalRemoting.Terminals.StreamProviding;

public interface ITerminalStreamProvider
{
    Terminal Terminal { get; set; }
    
    void AcquireStandardStreams()
    {
        Terminal.StandardInput = AcquireStandardInput();
        Terminal.StandardOutput = AcquireStandardOutput();
        Terminal.StandardError = AcquireStandardError();
    }
    
    Stream AcquireStandardInput();
    Stream AcquireStandardOutput();
    Stream AcquireStandardError();
}