using AdvancedConsoles.ConsoleStream;
using Terminals;
using Terminals.Types;

namespace AdvancedConsoles;


public class AnsiConsole(Terminal terminal)
{
    public Terminal Terminal { get; protected set; } = terminal;
    public ConsoleIn In { get; } = new ConsoleIn(terminal);
    public ConsoleOut Out { get; } = new ConsoleOut(terminal);
    public ConsoleError Error { get; } = new ConsoleError(terminal);
}