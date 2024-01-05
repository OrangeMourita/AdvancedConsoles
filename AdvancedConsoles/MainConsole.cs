using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;

public static class MainConsole
{
    static MainConsole()
    {
        Console = ResolveStandardConsole<AnsiConsole>();
    }
    
    
    public static AnsiConsole Console { get; set; }


    public static T ResolveStandardConsole<T>() where T : AnsiConsole, new()
    {
        T console = new T();
        
        console.In.SetStandard();
        console.Out.SetStandard();
        console.Error.SetStandard();
        

        return console;
    }

    public static void ResetInput()
    {
        Console.In = new StreamReader(System.Console.OpenStandardInput());
    }
    
    public static void ResetOutput()
    {
        Console.Out = new StreamWriter(System.Console.OpenStandardOutput());
    }
    
    public static void ResetError()
    {
        Console.Error = new StreamWriter(System.Console.OpenStandardError());
    }

    public static void ResetConsole<T>() where T : AnsiConsole, new()
    {
        Console = ResolveStandardConsole<T>();
    }
    
    
    public static void Write(string value)
    {
        Console.Write(value);
    }

    public static void Write<T>(T value)
    {
        Console.Write(value);
    }

    public static void WriteLine(string value)
    {
        Console.WriteLine(value);
    }

    public static void WriteLine<T>(T value)
    {
        Console.WriteLine(value);
    }
}