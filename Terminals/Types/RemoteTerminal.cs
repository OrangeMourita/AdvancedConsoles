using System.IO.Pipes;
using System.Runtime.InteropServices;
using Terminals.Emulators;

namespace Terminals.Types;

public class RemoteTerminal : Terminal
{
    private RemoteTerminal()
    {
        
    }

    private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1,1);    
    public int TerminalId { get; private init; }


    public static async Task<RemoteTerminal> CreateAsync(int terminalId, LaunchCommand launchCommand)
    {
        int remoteTerminalProcessId;
        
        await SemaphoreSlim.WaitAsync();
        try
        {
            string remoteTerminalGuestPath = GetRemoteTerminalGuestPath();
            launchCommand.Execute(remoteTerminalGuestPath,
                $"--processId {Environment.ProcessId} --terminalId {terminalId}");

            NamedPipeServerStream pidCommunicationPipe =
                new NamedPipeServerStream($"PidCommunication_{Environment.ProcessId}", PipeDirection.In);
            await pidCommunicationPipe.WaitForConnectionAsync().ConfigureAwait(false);

            using (StreamReader pidPipeReader = new StreamReader(pidCommunicationPipe))
            {
                remoteTerminalProcessId = int.Parse(await pidPipeReader.ReadLineAsync().ConfigureAwait(false));
            }
        }
        finally
        {
            SemaphoreSlim.Release();
        }
        
        RemoteTerminal remoteTerminal = new RemoteTerminal()
        {
            TerminalId = terminalId,
            ProcessId = remoteTerminalProcessId,
        };

        return remoteTerminal;
    }


    private static string GetRemoteTerminalGuestPath()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = "RemoteTerminalGuest";
        string fileExtension;
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            fileExtension = ".exe";
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            fileExtension = "";
        }
        else
        {
            fileExtension = "";
        }

        string qualifiedPath = Path.Combine(baseDirectory, fileName + fileExtension);
        if (Path.Exists(qualifiedPath))
            return qualifiedPath;

        throw new FileNotFoundException($"The assembly could not be found at '{qualifiedPath}'");
    }
}