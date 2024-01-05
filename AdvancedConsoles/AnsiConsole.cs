using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;


public class AnsiConsole : IConsoleIn, IConsoleOut
{
    public ConsoleIn In { get; set; } = Console.In;
    public ConsoleOut Out { get; set; } = Console.Out;
    public ConsoleError Error { get; set; } = Console.Error;
    
    
    public virtual void Write(string value)
    {
        Out.Write(value);
    }

    public virtual void Write<T>(T value)
    {
        Out.Write(value);
    }

    public virtual void WriteLine(string value)
    {
        Out.WriteLine(value);
    }

    public virtual void WriteLine<T>(T value)
    {
        Out.WriteLine(value);
    }
}