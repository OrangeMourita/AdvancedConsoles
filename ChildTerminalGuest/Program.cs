using System.IO.Pipes;
using CommandLine;

namespace ChildTerminalGuest;

public class Program
{
    static object ExitLock = new object();
    
    
    public static async Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<Options>(args)
            .WithParsedAsync(RunAsync);
        
        // TODO Replace with functionality to respond to client requests
        lock(ExitLock)
        {
            // Do whatever setup code you need here
            // once we are done wait
            Monitor.Wait(ExitLock);
        }
    }

    
    public static async Task RunAsync(Options options)
    {
        int terminalId = options.TerminalId;
        await EmitGuestProcessIdAsync(options.ProcessId);
    }

    public static async Task EmitGuestProcessIdAsync(int hostProcessId)
    {
        NamedPipeClientStream pidCommunicationPipe =
            new NamedPipeClientStream($"PidCommunication_{hostProcessId}");
        
        await pidCommunicationPipe.ConnectAsync().ConfigureAwait(false);
        
        using (StreamWriter pidPipeWriter = new StreamWriter(pidCommunicationPipe))
        {
            await pidPipeWriter.WriteLineAsync(Environment.ProcessId.ToString());
        }
    }
    
    
    static void ExitProgram()
    {
        lock(ExitLock)
        {
            Monitor.Pulse(ExitLock);
        }
    }
}