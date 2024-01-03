namespace AdvancedConsoles.ConsoleStream;

public class ConsoleError : IConsoleError
{
    public ConsoleError(StreamWriter streamWriter)
    {
        StreamWriter = streamWriter;
    }
    
    protected StreamWriter StreamWriter { get; }
    
    
    public static implicit operator ConsoleError(StreamWriter streamWriter)
    {
        return new ConsoleError(streamWriter);
    }
    
    
    public static ConsoleError ResolveStandardError()
    {
        return new StreamWriter(System.Console.OpenStandardError());
    }

    
    public void Write(string value)
    {
        StreamWriter.Write(value);
    }

    public void Write<T>(T value)
    {
        StreamWriter.Write(value);
    }
    

    public void WriteLine(string value)
    {
        StreamWriter.WriteLine(value);
    }

    public void WriteLine<T>(T value)
    {
        StreamWriter.WriteLine(value);
    }
}