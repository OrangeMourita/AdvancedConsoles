using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;

public abstract class Console : IConsoleIn, IConsoleOut
{
    public required ConsoleIn In { get; set; }
    public required ConsoleOut Out { get; set; }
    public required ConsoleError Error { get; set; }
    
    
    public void Write(string value)
    {
        Out.Write(value);
    }

    public void Write<T>(T value)
    {
        Out.Write(value);
    }

    public void WriteLine(string value)
    {
        Out.WriteLine(value);
    }

    public void WriteLine<T>(T value)
    {
        Out.WriteLine(value);
    }
}
