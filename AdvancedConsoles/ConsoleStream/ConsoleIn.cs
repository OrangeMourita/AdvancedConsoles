namespace AdvancedConsoles.ConsoleStream;

public class ConsoleIn : IConsoleIn
{
    public ConsoleIn(TextReader textReader)
    {
        TextReader = textReader;
    }
    
    protected TextReader TextReader { get; set; }
    
    
    public static implicit operator ConsoleIn(TextReader textReader)
    {
        return new ConsoleIn(textReader);
    }


    public void SetStandard()
    {
        TextReader = new StreamReader(System.Console.OpenStandardInput());
        System.Console.SetIn(TextReader);
    }
}