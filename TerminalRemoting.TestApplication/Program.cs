using System.Text;
using TerminalRemoting;
using TerminalRemoting.Terminals;
using TerminalRemoting.Terminals.StreamProviding;

namespace TerminalRemoting.TestApplication;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Terminal terminal = TerminalManager.MainTerminal;

        StreamReader sr = new StreamReader(terminal.StandardInput);
        Task<string?> task = sr.ReadLineAsync();
        
        terminal.StandardOutput.Write("Test test"u8);

        terminal.StandardOutput.Write(Encoding.UTF8.GetBytes(await task));
    }
}