using AdvancedConsoles.ConsoleStream;

namespace AdvancedConsoles;

public static class MainConsole
{
    static MainConsole()
    {
        Console = ResolveStandardConsole();
    }
    
    
    public static Console Console { get; set; }


    public static Console ResolveStandardConsole()
    {
        Console console = new AnsiConsole()
        {
            In = ConsoleIn.ResolveStandardInput(),
            Out = ConsoleOut.ResolveStandardOutput(),
            Error = ConsoleError.ResolveStandardError(),
        };

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

    public static void ResetConsole()
    {
        Console = ResolveStandardConsole();
    }
}