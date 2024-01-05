using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;

public class Console : IConsoleIn, IConsoleOut
{
    public ConsoleIn In { get; set; } = System.Console.In;
    public ConsoleOut Out { get; set; } = System.Console.Out;
    public ConsoleError Error { get; set; } = System.Console.Error;
    
    
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
