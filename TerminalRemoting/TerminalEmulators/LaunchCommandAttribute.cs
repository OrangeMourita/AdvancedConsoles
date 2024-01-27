namespace TerminalRemoting.TerminalEmulators;

[AttributeUsage(AttributeTargets.Field)]
public class LaunchCommandAttribute : Attribute
{
    public LaunchCommandAttribute(string commandTemplate)
    {
        LaunchCommand = new LaunchCommand(commandTemplate);
    }
    
    public LaunchCommandAttribute(LaunchCommand launchCommand)
    {
        LaunchCommand = launchCommand;
    }
    
    public LaunchCommand LaunchCommand { get; set; }
}