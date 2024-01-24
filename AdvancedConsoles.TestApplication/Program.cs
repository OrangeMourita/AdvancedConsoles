using System.Text;
using Terminals;

namespace AdvancedConsoles.TestApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        MemoryStream ms = new MemoryStream();
        StreamWriter sw = new StreamWriter(ms)
        {
            AutoFlush = true
        };
        StreamReader sr = new StreamReader(ms);
        
        Terminal terminal = new MainTerminal();
        AnsiConsole ansiConsole = new AnsiConsole(terminal);
        
        string? readLine = ansiConsole.In.ReadLine();
        ansiConsole.Out.WriteLine(readLine);
    }
}