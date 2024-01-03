namespace AdvancedConsoles.ConsoleStream;

public interface IConsoleOut
{
    public void Write(string value);
    public void Write<T>(T value);
    
    public void WriteLine(string value);
    public void WriteLine<T>(T value);

    public virtual void WriteLine()
    {
        Write(Environment.NewLine);
    }
}