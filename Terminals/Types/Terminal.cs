namespace Terminals.Types;

public abstract class Terminal
{
    public int ProcessId { get; internal init; }
    
    public Stream StandardInput { get; internal set; }
    public Stream StandardOutput { get; internal set; }
    public Stream StandardError { get; internal set; }
}
