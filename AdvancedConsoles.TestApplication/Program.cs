using System;
using System.Diagnostics;
using System.Text;
using TerminalRemoting;
using TerminalRemoting.Terminals;

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