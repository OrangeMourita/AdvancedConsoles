using CommandLine;


namespace RemoteTerminalGuest;

public class Options
{
    [Option("processId", Required = true, HelpText = "The process id (pid) of the host application the new remote terminal belongs to.")]
    public int ProcessId { get; set; }
    
    [Option("terminalId", Required = true, HelpText = "The terminal id (tid) of the new remote terminal.")]
    public int TerminalId { get; set; }
}