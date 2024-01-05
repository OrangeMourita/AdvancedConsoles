namespace AdvancedConsoles.ConsoleStream;

public class ConsoleOut : IConsoleOut
{
    public ConsoleOut(TextWriter textWriter)
    {
        TextWriter = textWriter;
    }
    
    protected TextWriter TextWriter { get; set; }
    
    
    public static implicit operator ConsoleOut(TextWriter textWriter)
    {
        return new ConsoleOut(textWriter);
    }

    
    public void SetStandard()
    {
        StreamWriter standardOutWriter = new StreamWriter(System.Console.OpenStandardOutput())
        {
            AutoFlush = true
        };
        
        TextWriter = standardOutWriter;
        System.Console.SetOut(TextWriter);
    }

    public void Write(string value)
    {
        TextWriter.Write(value);
    }

    public void Write<T>(T value)
    {
        TextWriter.Write(value);
    }
    

    public void WriteLine(string value)
    {
        TextWriter.WriteLine(value);
    }

    public void WriteLine<T>(T value)
    {
        TextWriter.WriteLine(value);
    }
}