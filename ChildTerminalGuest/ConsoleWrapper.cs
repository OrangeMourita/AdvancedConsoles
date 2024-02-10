using System.Runtime.Versioning;

namespace ChildTerminalGuest;

public class ConsoleWrapper
{
    public string Title
    {
        [SupportedOSPlatform("windows")] get => Console.Title;
        set => Console.Title = value;
    }
    
    // Todo: Exists solely for testing 
    public int ProcessId => Environment.ProcessId;
}