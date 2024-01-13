using System.Reflection.PortableExecutable;
using System.Text;
using Console = System.Console;

namespace Terminals;

public abstract class Terminal
{
    protected Stream StandardInput { get; init; }
    protected Stream StandardOutput { get; init; }
    protected Stream StandardError { get; init; }


    public virtual void Write(char value)
    {
        byte charByte = (byte) value;
        StandardOutput.WriteByte(charByte);
    }
    
    public virtual void Write(string value)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(value);
        StandardOutput.Write(buffer, 0, buffer.Length);
    }

    
    public virtual void WriteLine(char value)
    {
        Write(value + Environment.NewLine);
    }
    
    public virtual void WriteLine(string value)
    {
        Write(value + Environment.NewLine);
    }

    
    public virtual int Read()
    {
        byte[] buffer = new byte[4];
        
        int readBytes = StandardInput.Read(buffer, 0, buffer.Length);
        string unicodeString = Encoding.UTF8.GetString(buffer);

        return unicodeString[0];
    }

    public virtual string? ReadLine()
    {
        throw new NotImplementedException();
    }
}
