namespace AdvancedConsoles;

public interface IConsole
{
    public void Write(string value);
    public void Write<T>(T value);
    public void Write<T>(T value, params object[] args);
    
    public void WriteLine(string value);
    public void WriteLine<T>(T value);
    public void WriteLine<T>(T value, params object[] args);

    public virtual void WriteLine()
    {
        Write(Environment.NewLine);
    }
}
