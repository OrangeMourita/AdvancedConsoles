namespace AdvancedConsoles.ConsoleStream;

public class ConsoleIn : IConsoleIn
{
    public ConsoleIn(StreamReader streamReader)
    {
        StreamReader = streamReader;
    }
    
    protected StreamReader StreamReader { get; }
    
    
    public static implicit operator ConsoleIn(StreamReader streamReader)
    {
        return new ConsoleIn(streamReader);
    }


    public static ConsoleIn ResolveStandardInput()
    {
        return new StreamReader(System.Console.OpenStandardInput());
    }
}