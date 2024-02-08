namespace Terminals.Emulators;

public class EmulatorLaunchingException : Exception
{
    public EmulatorLaunchingException()
    {
        
    }
    
    public EmulatorLaunchingException(string message) : base(message)
    {
        
    }
    
    public EmulatorLaunchingException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}