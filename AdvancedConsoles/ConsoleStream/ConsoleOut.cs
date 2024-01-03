namespace AdvancedConsoles.ConsoleStream;

public class ConsoleOut : IConsoleOut
{
    public ConsoleOut(StreamWriter streamWriter)
    {
        StreamWriter = streamWriter;
    }
    
    protected StreamWriter StreamWriter { get; }
    
    
    public static implicit operator ConsoleOut(StreamWriter streamWriter)
    {
        return new ConsoleOut(streamWriter);
    }

    
    public static ConsoleOut ResolveStandardOutput()
    {
        return new StreamWriter(System.Console.OpenStandardOutput());
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