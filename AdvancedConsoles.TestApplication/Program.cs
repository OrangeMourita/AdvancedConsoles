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
        ansiConsole.Out.Write('H');

        ansiConsole.Out = sw;
        

        
        ansiConsole.Out.Write('i');
        
        ansiConsole.Out.Reset();

        ansiConsole.Out.Write("HEY SISTER; WHERE THE HELL IS YOU BABA BROTHER");

        ms.Seek(0, SeekOrigin.Begin);
        // Console.Write(sr.ReadToEnd());
    }
}