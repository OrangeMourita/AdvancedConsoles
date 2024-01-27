namespace TerminalRemoting.Terminals;

public abstract class Terminal
{
    public Stream StandardInput { get; internal set; }
    public Stream StandardOutput { get; internal set; }
    public Stream StandardError { get; internal set; }
}
