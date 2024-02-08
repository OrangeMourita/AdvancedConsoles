using Terminals;
using Terminals.Types;

namespace AdvancedConsoles.TestApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        Terminal terminal = TerminalManager.MainTerminal;
        AnsiConsole ansiConsole = new AnsiConsole(terminal);
        
        ansiConsole.Out.WriteLine($"pid: {Environment.ProcessId}");
        
        string? readLine = ansiConsole.In.ReadLine();
        ansiConsole.Out.WriteLine(readLine);
        
        ansiConsole.In.ReadLine();
    }
}