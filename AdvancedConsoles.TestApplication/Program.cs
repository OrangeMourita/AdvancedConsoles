using System.Text;
using AdvancedConsoles.ConsoleStream;
using Terminals;

namespace AdvancedConsoles.TestApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        MemoryStream ms = new MemoryStream();
        StreamWriter sw = new StreamWriter(ms);
        StreamReader sr = new StreamReader(ms);


        Terminal terminal = new MainTerminal();
        
        AnsiConsole ansiConsole = new AnsiConsole(terminal);
        ansiConsole.Out.WriteLine("");
    }
}