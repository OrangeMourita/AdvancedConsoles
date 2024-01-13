using System.Text;
using Terminals;

namespace AdvancedConsoles.ConsoleStream;

public class ConsoleIn : TextReader
{
    protected ConsoleIn(TextReader textReader)
    {
        RedirectedStreamReader = textReader;
        IsRedirected = true;
    }

    internal ConsoleIn(Terminal terminal, bool initialize)
    {
        InitialTerminal = terminal;
        Terminal = terminal;
        IsRedirected = false;
    }
    
    public ConsoleIn(Terminal terminal)
    {
        Terminal = terminal;
        IsRedirected = false;
    }

    public ConsoleIn(Terminal terminal, TextReader redirectedStreamReader, bool autoFlush = false)
    {
        Terminal = terminal;
        RedirectedStreamReader = redirectedStreamReader;
        IsRedirected = true;
    }

    
    internal Terminal? InitialTerminal { get; set; }
    internal Terminal? Terminal { get; set; }
    internal TextReader? RedirectedStreamReader { get; set; }
    public bool IsRedirected { get; protected set; }
    

    
    public static implicit operator ConsoleIn(StreamReader streamReader)
    {
        return new ConsoleIn(streamReader);
    }
    
    public static implicit operator ConsoleIn(Stream stream)
    {
        return new ConsoleIn(new StreamReader(stream));
    }


    /// <summary>
    /// Resets back to the standard output.
    /// </summary>
    public void Reset()
    {
        RedirectedStreamReader = null;
        IsRedirected = false;
        Terminal = InitialTerminal;
    }
    
    
    
    /// <summary>
    /// Reads either from the terminal's standard input or to the redirected stream if provided.
    /// </summary>
    /// <returns>The read character as an in</returns>
    protected int ReadFromCurrentIn()
    {
        if (IsRedirected && RedirectedStreamReader is not null)
        {
            return RedirectedStreamReader!.Read();
        }

        IsRedirected = false;
        return Terminal!.Read();
    }
    
    
    /// <inheritdoc/>
    /// <remarks>
    /// You should consider calling <see cref="ReadFromCurrentIn"/> when overriding this method.
    /// </remarks>
    public override int Read()
    {
        return ReadFromCurrentIn();
    }

    /// <inheritdoc/>
    /// <remarks>
    /// You should consider calling <see cref="ReadLineFromCurrentIn"/> when overriding this method.
    /// </remarks>
    public override string ReadLine()
    {
        throw new NotImplementedException();
        // return ReadLineFromCurrentIn();
    }
}