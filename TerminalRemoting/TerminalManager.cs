using System.Collections.ObjectModel;
using TerminalRemoting.Remoting;
using TerminalRemoting.TerminalEmulators;
using TerminalRemoting.Terminals;
using TerminalRemoting.Terminals.StreamProviding;

namespace TerminalRemoting;

public static class TerminalManager
{
    private static MainTerminal _mainTerminal;
    
    static TerminalManager()
    {
        InitializeMainTerminal();
    }

    private static Collection<Terminal> AvailableTerminals { get; set; } = new Collection<Terminal>();

    public static MainTerminal MainTerminal
    {
        get => _mainTerminal;
        private set
        {
            _mainTerminal = value;
            AvailableTerminals.Insert(0, MainTerminal);
        } 
    }


    
    
    private static void InitializeMainTerminal()
    {
        MainTerminal mainTerminal = new MainTerminal();
        
        ITerminalStreamProvider terminalStreamProvider = MainTerminalStreamProvider.CreateStandardStreamProvider(mainTerminal);;
        terminalStreamProvider.AcquireStandardStreams();

        MainTerminal = mainTerminal;
    }
    
    
    /// <summary>
    /// Initializes the <see cref="MainTerminal"/> (again) with a custom <see cref="ITerminalStreamProvider"/>.
    /// This method method is slow due to being heavily reflection based.
    /// </summary>
    /// <typeparam name="TStreamProvider"></typeparam>
    public static MainTerminal InitializeMainTerminal<TStreamProvider>() where TStreamProvider : ITerminalStreamProvider
    {
        MainTerminal mainTerminal = new MainTerminal();
        TStreamProvider terminalStreamProvider = (TStreamProvider) typeof(TStreamProvider).GetMethod("CreateStandardStreamProvider").Invoke(null, [mainTerminal]);
        terminalStreamProvider.AcquireStandardStreams();

        MainTerminal = mainTerminal;

        return MainTerminal;
    }

    
    public static RemoteTerminal OpenNewTerminalWindow(TerminalEmulator terminalEmulator)
    {
        return OpenNewTerminalWindow(terminalEmulator.GetLaunchCommand());
    }
    public static RemoteTerminal OpenNewTerminalWindow(LaunchCommand launchCommand) 
    {
        // launchCommand.Execute(path, $"--pid {Environment.ProcessId} --tid {tid}");
        
        MainTerminal mainTerminal = new MainTerminal();
        ITerminalStreamProvider terminalStreamProvider = MainTerminalStreamProvider.CreateStandardStreamProvider(mainTerminal);;
        terminalStreamProvider.AcquireStandardStreams();

        throw new NotImplementedException();
    }
    
    public static RemoteTerminal OpenNewTerminalWindow<TStreamProvider>(TerminalEmulator terminalEmulator) where TStreamProvider : ITerminalStreamProvider
    {
        return OpenNewTerminalWindow<TStreamProvider>(terminalEmulator.GetLaunchCommand());
    }
    public static RemoteTerminal OpenNewTerminalWindow<TStreamProvider>(LaunchCommand launchCommand) where TStreamProvider : ITerminalStreamProvider
    {
        // launchCommand.Execute(path, $"--pid {Environment.ProcessId} --tid {tid}");
        
        MainTerminal mainTerminal = new MainTerminal();

        TStreamProvider terminalStreamProvider = (TStreamProvider) typeof(TStreamProvider).GetMethod("CreateStandardStreamProvider").Invoke(null, [mainTerminal]);
        terminalStreamProvider.AcquireStandardStreams();

        throw new NotImplementedException();
    }
}