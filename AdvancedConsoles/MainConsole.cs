namespace AdvancedConsoles;

public class MainConsole : IConsole
{
    public void Write(string value)
    {
        Console.Write(value);
    }

    public void Write<T>(T value)
    {
        throw new NotImplementedException();
    }

    public void Write<T>(T value, params object[] args)
    {
        throw new NotImplementedException();
    }

    public void WriteLine(string value)
    {
        Write(value);
        Write(Environment.NewLine);
    }

    public void WriteLine<T>(T value)
    {
        Write(value);
        Write(Environment.NewLine);
    }

    public void WriteLine<T>(T value, params object[] args)
    {
        Write(value);
        Write(Environment.NewLine, args);
    }
}