namespace Terminals.Emulators;

public enum TerminalEmulator
{
    [LaunchCommand("gnome-terminal -- {0} {1}")]
    GnomeTerminal,
    
    [LaunchCommand("xfce4-terminal -e '{0} {1}'")]
    Xfce4Terminal,
    
    [LaunchCommand("xterm -e {0} {1}")]
    XTerm,
    
    [LaunchCommand("konsole -e {0} {1}")]
    Konsole
}