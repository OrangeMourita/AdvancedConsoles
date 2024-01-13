using AdvancedConsoles.ConsoleStream;
using Terminals;

namespace AdvancedConsoles;

public class AnsiConsole(Terminal terminal)
{
    private ConsoleOut _out = new ConsoleOut(terminal, true);
    
    
    public Terminal Terminal { get; protected set; } = terminal;

    public ConsoleOut Out
    {
        get => _out;
        set => SetOut(value);
    }


    public void SetOut(ConsoleOut newOut)
    {
        newOut.InitialTerminal = _out.InitialTerminal;
        newOut.AutoFlush = _out.AutoFlush;
        newOut.Terminal ??= _out.Terminal;
        
        _out = newOut;
    }
}