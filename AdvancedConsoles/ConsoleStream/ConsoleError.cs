using System.IO;
using System.Text;
using System.Threading.Tasks;
using Terminals.Types;

namespace AdvancedConsoles.ConsoleStream;

public class ConsoleError : TextWriter
{
    internal ConsoleError(Terminal terminal)
    {
        TerminalErrorWriter = new StreamWriter(terminal.StandardError)
        {
            AutoFlush = true
        };
    }
    
    protected TextWriter TerminalErrorWriter { get; set; }
    protected TextWriter? RedirectedStreamWriter { get; set; }
    protected TextWriter SelectedWriter => !IsRedirected ? TerminalErrorWriter : RedirectedStreamWriter!;
    public bool IsRedirected { get; protected set; }
    public override Encoding Encoding => SelectedWriter.Encoding;




    public override void Write(char value)
    {
        SelectedWriter.Write(value);
    }
    
    public override Task WriteAsync(char value)
    {
        return SelectedWriter.WriteAsync(value);
    }
    
    
    
    public void RedirectTo(Stream stream)
    {
        IsRedirected = true;
        RedirectedStreamWriter = new StreamWriter(stream)
        {
            AutoFlush = true
        };
    }

    public void RedirectTo(TextWriter textWriter)
    {
        IsRedirected = true;
        RedirectedStreamWriter = textWriter;
    }
    
    public void Reset()
    {
        IsRedirected = false;
        RedirectedStreamWriter = null;
    }
}