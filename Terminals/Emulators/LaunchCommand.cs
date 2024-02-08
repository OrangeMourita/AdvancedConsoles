using System.Diagnostics;

namespace Terminals.Emulators;

public class LaunchCommand
{
    private readonly string _commandTemplate; 
    
    public LaunchCommand()
    {
        
    }

    public LaunchCommand(string commandTemplate)
    {
        CommandTemplate = commandTemplate;
    }
    
    
    public string CommandTemplate
    {
        get => _commandTemplate;
        init => _commandTemplate = value.Replace('\'', '"');
    }


    public void Execute(string injectedCommand, string injectedCommandArguments = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(CommandTemplate, nameof(CommandTemplate));

        
        string[] fullCommand = GetFullCommand(injectedCommand, injectedCommandArguments);
        
        string fileName = fullCommand[0];
        IEnumerable<string> arguments = fullCommand.Skip(1);
        
        Process process = new Process();
        process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        process.StartInfo.FileName = fileName;
        
        foreach (string argument in arguments)
        {
            process.StartInfo.ArgumentList.Add(argument);
        }

        try
        {
            process.Start();
        }
        catch (Exception e)
        {
            throw new EmulatorLaunchingException("Failed to launch the specified emulator", e);
        }
    }


    private string[] GetFullCommand(string injectedCommand, string injectedCommandArguments)
    {
        string embeddedCommand = string.Format(CommandTemplate, injectedCommand, injectedCommandArguments);
        string[] fullCommand = embeddedCommand
            .Split('"')
            .Select((element, index) => index % 2 == 0  // If even index
                ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                : new string[] { element })  // Keep the entire item
            .SelectMany(element => element).ToArray();

        return fullCommand;
    }
}