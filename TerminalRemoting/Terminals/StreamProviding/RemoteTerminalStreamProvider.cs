namespace TerminalRemoting.Terminals.StreamProviding;

public class RemoteTerminalStreamProvider : ITerminalStreamProvider
{

    private RemoteTerminalStreamProvider(Terminal terminal)
    {
        Terminal = terminal;
    }

    public Terminal Terminal { get; set; }



    public static ITerminalStreamProvider CreateStandardStreamProvider(Terminal terminal)
    {
        return new RemoteTerminalStreamProvider(terminal);
    }



    public virtual Stream AcquireStandardInput()
    {
        throw new NotImplementedException();
    }

    public virtual Stream AcquireStandardOutput()
    {
        throw new NotImplementedException();
    }

    public virtual Stream AcquireStandardError()
    {
        throw new NotImplementedException();
    }
    
}