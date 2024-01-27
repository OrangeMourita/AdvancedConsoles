namespace TerminalRemoting.TerminalEmulators;

public enum TerminalEmulator
{
    
    
    [LaunchCommand("gnome-terminal -- {0} {1}")]
    GnomeTerminal
}