namespace AdvancedConsoles.TestApplication;

class Program
{
    static void Main(string[] args)
    {
        AnsiConsole console = new AnsiConsole()
        {
            Error = System.Console.Error,
            Out = System.Console.Out,
            In = System.Console.In,
        };
        
        console.WriteLine("BAUM");
        MainConsole.Console.WriteLine("Hi");
    }
}
