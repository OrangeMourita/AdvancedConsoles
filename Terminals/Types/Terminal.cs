using Terminals.StreamProviding.Streams;

namespace Terminals.Types;

public abstract class Terminal
{
    public int ProcessId { get; internal init; }
    
    public TerminalStream StandardInput { get; internal set; }
    public TerminalStream StandardOutput { get; internal set; }
    public TerminalStream StandardError { get; internal set; }
}
