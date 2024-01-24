using System.Text;
using Terminals;

namespace AdvancedConsoles.ConsoleStream;

public class ConsoleIn : TextReader
{
    internal ConsoleIn(Terminal terminal)
    {
        TerminalInReader = new StreamReader(terminal.StandardInput);
    }
    
    protected TextReader TerminalInReader { get; set; }
    protected TextReader? RedirectedStreamReader { get; set; }
    protected TextReader SelectedReader => !IsRedirected ? TerminalInReader : RedirectedStreamReader!;
    public bool IsRedirected { get; protected set; }



    public override int Read()
    {
        return SelectedReader.Read();
    }
    
    
    public void RedirectTo(Stream stream)
    {
        IsRedirected = true;
        RedirectedStreamReader = new StreamReader(stream);
    }

    public void RedirectTo(TextReader textReader)
    {
        IsRedirected = true;
        RedirectedStreamReader = textReader;
    }
    
    public void Reset()
    {
        IsRedirected = false;
        RedirectedStreamReader = null;
    }
}