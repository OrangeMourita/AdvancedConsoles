namespace AdvancedConsoles.ConsoleStream;

public class ConsoleError : IConsoleError
{
    public ConsoleError(TextWriter textWriter)
    {
        TextWriter = textWriter;
    }
    
    protected TextWriter TextWriter { get; set; }
    
    
    public static implicit operator ConsoleError(TextWriter textWriter)
    {
        return new ConsoleError(textWriter);
    }
    
    
    public void SetStandard()
    {
        StreamWriter standardErrorWriter = new StreamWriter(System.Console.OpenStandardError())
        {
            AutoFlush = true
        };
        
        TextWriter = standardErrorWriter;
        System.Console.SetError(TextWriter);
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