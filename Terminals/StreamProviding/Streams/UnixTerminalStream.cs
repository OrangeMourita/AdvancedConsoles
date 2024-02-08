namespace Terminals.StreamProviding.Streams;

public class UnixTerminalStream : FileStream
{
    // TODO Make it derive from Stream or TerminalStream which then derives from Stream (you have to implement the IO functionality)
    private UnixTerminalStream(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare) 
        : base(path, fileMode, fileAccess, fileShare)
    {
        
    }
    

    public static UnixTerminalStream Open(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
    {
        return new UnixTerminalStream(path, fileMode, fileAccess, fileShare);
    }
}