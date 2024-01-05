using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;

public static class MainConsole
{
    static MainConsole()
    {
        Console = ResolveStandardConsole<AnsiConsole>();
    }
    
    
    public static Console Console { get; set; }


    public static T ResolveStandardConsole<T>() where T : Console, new()
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

    public static void ResetConsole<T>() where T : Console, new()
    {
        Console = ResolveStandardConsole<T>();
    }
}