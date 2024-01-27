using System.Diagnostics;

namespace TerminalRemoting.TerminalEmulators;

public class LaunchCommand
{
    public LaunchCommand()
    {
        
    }

    public LaunchCommand(string commandTemplate)
    {
        CommandTemplate = commandTemplate;
    }
    
    
    public string CommandTemplate { get; init; }
    
    
    
    public void Execute(string injectedCommand, string injectedCommandArguments = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(CommandTemplate, nameof(CommandTemplate));
        
        string[] command = string.Format(CommandTemplate, injectedCommand, injectedCommandArguments).Split(' ');
        string fileName = command[0];
        IEnumerable<string> arguments = command.Skip(1);
        
        Process process = new Process();
        process.StartInfo.FileName = fileName;
        process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        foreach (string argument in arguments)
        {
            process.StartInfo.ArgumentList.Add(argument);
        }
        
        process.Start();
    }
}