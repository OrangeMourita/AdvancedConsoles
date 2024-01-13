using System.Runtime.InteropServices;


namespace Terminals;

public class MainTerminal : Terminal
{
    public MainTerminal()
    {
        StandardInput = Console.OpenStandardInput();
        StandardOutput = Console.OpenStandardOutput();
        StandardError = Console.OpenStandardError();
    }


    
}