using Terminals.Emulators;
using Terminals.Types;

namespace Terminals.Tests;

public class RemoteTerminalEmulatorTests
{
    [Fact]
    public async Task Open_New_Remote_Terminal_Xfce4Terminal()
    {
        RemoteTerminal remoteTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.Xfce4Terminal);
        
        using (StreamWriter writer = new StreamWriter(remoteTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(remoteTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Remote_Terminal_GnomeTerminal()
    {
        RemoteTerminal remoteTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.GnomeTerminal);

        using (StreamWriter writer = new StreamWriter(remoteTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(remoteTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Remote_Terminal_XTerm()
    {
        RemoteTerminal remoteTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.XTerm);

        using (StreamWriter writer = new StreamWriter(remoteTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(remoteTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Remote_Terminal_Konsole()
    {
        RemoteTerminal remoteTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.Konsole);

        using (StreamWriter writer = new StreamWriter(remoteTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(remoteTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }

}