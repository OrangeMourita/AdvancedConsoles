using Terminals.Emulators;
using Terminals.StreamProviding.Streams;
using Terminals.Types;

namespace Terminals.Tests;

public class TerminalEmulatorTests
{
    [Fact]
    public async Task Open_New_Child_Terminal_Xfce4Terminal()
    {
        ((UnixTerminalStream) TerminalManager.RootTerminal.StandardOutput).Write("Wer kann mich prüfen?"u8);
        
        ChildTerminal childTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.Xfce4Terminal);
        
        using (StreamWriter writer = new StreamWriter(childTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(childTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Child_Terminal_GnomeTerminal()
    {
        ChildTerminal childTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.GnomeTerminal);

        using (StreamWriter writer = new StreamWriter(childTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(childTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Child_Terminal_XTerm()
    {
        ChildTerminal childTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.XTerm);
        
        using (StreamWriter writer = new StreamWriter(childTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(childTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }
    
    [Fact]
    public async Task Open_New_Child_Terminal_Konsole()
    {
        ChildTerminal childTerminal = await TerminalManager.OpenNewTerminalWindowAsync(TerminalEmulator.Konsole);

        using (StreamWriter writer = new StreamWriter(childTerminal.StandardOutput))
        {
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Hello World!");
            
            StreamReader reader = new StreamReader(childTerminal.StandardInput);
            await writer.WriteLineAsync(await reader.ReadLineAsync());
        }
    }

}