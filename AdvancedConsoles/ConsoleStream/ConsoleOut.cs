using System.Text;
using Terminals;

namespace AdvancedConsoles.ConsoleStream;

public class ConsoleOut : TextWriter
{
    protected ConsoleOut(TextWriter textWriter)
    {
        RedirectedStreamWriter = textWriter;
        IsRedirected = true;
    }

    internal ConsoleOut(Terminal terminal, bool initialize)
    {
        InitialTerminal = terminal;
        Terminal = terminal;
        IsRedirected = false;
    }
    
    public ConsoleOut(Terminal terminal)
    {
        Terminal = terminal;
        IsRedirected = false;
    }

    public ConsoleOut(Terminal terminal, TextWriter redirectedStreamWriter, bool autoFlush = false)
    {
        Terminal = terminal;
        RedirectedStreamWriter = redirectedStreamWriter;
        IsRedirected = true;
    }

    
    protected bool RedirectedStreamWriterAutoFlush { get; set; } = false;
    internal Terminal? InitialTerminal { get; set; }
    internal Terminal? Terminal { get; set; }
    internal TextWriter? RedirectedStreamWriter { get; set; }
    public bool IsRedirected { get; protected set; }
    public bool AutoFlush
    {
        get => !IsRedirected || RedirectedStreamWriterAutoFlush;
        set => RedirectedStreamWriterAutoFlush = value;
    }
    
    public override Encoding Encoding { get; } = Encoding.UTF8;


    
    public static implicit operator ConsoleOut(StreamWriter streamWriter)
    {
        return new ConsoleOut(streamWriter);
    }
    
    public static implicit operator ConsoleOut(Stream stream)
    {
        return new ConsoleOut(new StreamWriter(stream));
    }


    /// <summary>
    /// Resets back to the standard output.
    /// </summary>
    public void Reset()
    {
        RedirectedStreamWriter = null;
        IsRedirected = false;
        Terminal = InitialTerminal;
    }
    
    
    
    /// <summary>
    /// Writes <paramref name="value"/> either to the terminal's standard output or to the redirected stream if one is provided.
    /// </summary>
    /// <param name="value"></param>
    // ReSharper disable once MemberCanBePrivate.Global
    protected void WriteToCurrentOut(char value)
    {
        if (IsRedirected && RedirectedStreamWriter is not null)
        {
            RedirectedStreamWriter!.Write(value);
            if (AutoFlush) RedirectedStreamWriter.Flush();
            return;
        }

        IsRedirected = false;
        Terminal!.Write(value);
    }
    
    
    /// <summary>
    /// Writes <paramref name="value"/> to either stdio of the terminal or the redirected stream.
    /// </summary>
    /// <param name="value"></param>
    // ReSharper disable once MemberCanBePrivate.Global
    protected void WriteToCurrentOut(string? value)
    {
        if (value is null)
            return;
        
        if (IsRedirected && RedirectedStreamWriter is not null)
        {
            RedirectedStreamWriter!.Write(value);
            if (AutoFlush) RedirectedStreamWriter.Flush();
            return;
        }

        IsRedirected = false;
        Terminal!.Write(value);
    }
    
    
    /// <inheritdoc/>
    /// <remarks>
    /// You should consider calling <see cref="WriteToCurrentOut(char)"/> when overriding this method.
    /// </remarks>
    public override void Write(char value)
    {
        WriteToCurrentOut(value);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// You should consider calling <see cref="WriteToCurrentOut(string)"/> when overriding this method.
    /// </remarks>
    public override void Write(string? value)
    {
        WriteToCurrentOut(value);
    }
}