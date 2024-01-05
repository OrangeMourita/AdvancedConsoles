namespace AdvancedConsoles.TestApplication;

class Program
{
    static void Main(string[] args)
    {
        AnsiConsole console = new AnsiConsole()
        {
            Error = Console.Error,
            Out = Console.Out,
            In = Console.In,
        };
        
        MainConsole.WriteLine("Hallo");
    }
}
