using System.IO.Pipes;
using CommandLine;
using StreamJsonRpc;

namespace ChildTerminalGuest;

public class Program
{ 
    private static readonly object ExitLock = new object();
    private static NamedPipeServerStream _communicationPipe = null!;
    private static JsonRpc _rpc = null!;
    
    
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

        await CreateCommunicationStreamAsync();
        _rpc.StartListening();
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

    public static async Task CreateCommunicationStreamAsync()
    {
        // Todo: Move functionality to TerminalCommunicationStreamServer
        _communicationPipe = new NamedPipeServerStream($"ChildTerminalCommunication_{Environment.ProcessId}");
        await _communicationPipe.WaitForConnectionAsync();
        
        _rpc = JsonRpc.Attach(_communicationPipe, new ConsoleWrapper());
    }
    
    
    static void ExitProgram()
    {
        lock(ExitLock)
        {
            Monitor.Pulse(ExitLock);
        }
    }
}