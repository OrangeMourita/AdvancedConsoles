using Terminals.Types;

namespace Terminals.StreamProviding.Providers;

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
        return Stream.Null;
    }

    public virtual Stream AcquireStandardOutput()
    {
        return Stream.Null;    }

    public virtual Stream AcquireStandardError()
    {
        return Stream.Null;    }
    
}