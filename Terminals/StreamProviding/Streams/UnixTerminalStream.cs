namespace Terminals.StreamProviding.Streams;

public class UnixTerminalStream : TerminalStream
{
    private readonly FileStream _fileStream;
    
    
    private UnixTerminalStream(string path, FileStreamOptions fileStreamOptions)
    {
        _fileStream = new FileStream(path, fileStreamOptions);
    }

    
    public new static UnixTerminalStream Null { get; } = new UnixTerminalStream("/dev/null", new FileStreamOptions
        {
            Mode = FileMode.Open, 
            Access = FileAccess.ReadWrite, 
            Share = FileShare.ReadWrite, 
            Options = FileOptions.WriteThrough
        });
    

    public static UnixTerminalStream Open(TerminalStreamType type)
    {
        return Open($"/proc/self/fd/{(int) type}", type);
    }


    public static UnixTerminalStream Open(int processId, TerminalStreamType type)
    {
        return Open($"/proc/{processId}/fd/{(int) type}", type);
    }
    
    public static UnixTerminalStream Open(string path, TerminalStreamType type) 
    {
        FileStreamOptions fileStreamOptions = new FileStreamOptions
        {
            Mode = FileMode.Open, 
            Share = FileShare.ReadWrite,
            Options = FileOptions.WriteThrough,
            Access = type switch
            {
                TerminalStreamType.In => FileAccess.Read,
                TerminalStreamType.Out => FileAccess.Write,
                TerminalStreamType.Error => FileAccess.Write,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            }
        };
        
        return new UnixTerminalStream(path, fileStreamOptions);
    }
    
    
    public override void Flush()
    {
        _fileStream.Flush();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return _fileStream.Read(buffer, offset, count);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return _fileStream.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
        _fileStream.SetLength(value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        _fileStream.Write(buffer, offset, count);
    }

    public override bool CanRead => _fileStream.CanRead;
    public override bool CanSeek => _fileStream.CanSeek;
    public override bool CanWrite => _fileStream.CanWrite;
    public override long Length => _fileStream.Length;

    public override long Position
    {
        get => _fileStream.Position;
        set => _fileStream.Position = value;
    }
}