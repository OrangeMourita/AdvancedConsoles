namespace TerminalRemoting.Terminals.StreamProviding;

public class MainTerminalStreamProvider : ITerminalStreamProvider
{

    private MainTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }



    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new MainTerminalStreamProvider(terminal);
    }



    public virtual Stream AcquireStandardInput()
    {
        return Console.OpenStandardInput();
    }

    public virtual Stream AcquireStandardOutput()
    {
        return Console.OpenStandardOutput();
    }

    public virtual Stream AcquireStandardError()
    {
        return Console.OpenStandardError();
    }
    
}