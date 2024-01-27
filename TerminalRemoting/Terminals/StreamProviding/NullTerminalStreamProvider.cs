namespace TerminalRemoting.Terminals.StreamProviding;

public class NullTerminalStreamProvider : ITerminalStreamProvider
{

    private NullTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }

    
    
    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new NullTerminalStreamProvider(terminal);
    }



    public virtual Stream AcquireStandardInput()
    {
        return File.Open("/dev/null", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
    }

    public virtual Stream AcquireStandardOutput()
    {
        return File.Open("/dev/null", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
    }

    public virtual Stream AcquireStandardError()
    {
        return File.Open("/dev/null", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
    }
    
}