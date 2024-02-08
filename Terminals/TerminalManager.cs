using System.Collections.ObjectModel;
using Terminals.Emulators;
using Terminals.StreamProviding;
using Terminals.StreamProviding.Providers;
using Terminals.Types;

namespace Terminals;

public static class TerminalManager
{
    private static MainTerminal _mainTerminal;
    
    static TerminalManager()
    {
        InitializeMainTerminal();
    }

    private static Collection<Terminal> AvailableTerminals { get; set; } = [];

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
        MainTerminal mainTerminal = new MainTerminal()
        {
            ProcessId = Environment.ProcessId
        };
        
        ITerminalStreamProvider terminalStreamProvider = MainTerminalStreamProvider.CreateStandardStreamProvider(mainTerminal);;
        terminalStreamProvider.AcquireStandardStreams();

        MainTerminal = mainTerminal;
    }
    
    
    /// <summary>
    /// Initializes the <see cref="MainTerminal"/> (again) with a custom <see cref="ITerminalStreamProvider"/>.
    /// This method method is slower due to being reflection based.
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

    
    public static Task<RemoteTerminal> OpenNewTerminalWindowAsync(TerminalEmulator terminalEmulator)
    {
        return OpenNewTerminalWindowAsync(terminalEmulator.GetLaunchCommand());
    }
    
    public static Task<RemoteTerminal> OpenNewTerminalWindowAsync<TStreamProvider>(TerminalEmulator terminalEmulator) where TStreamProvider : ITerminalStreamProvider
    {
        return OpenNewTerminalWindowAsync<TStreamProvider>(terminalEmulator.GetLaunchCommand());
    }
    
    
    public static Task<RemoteTerminal> OpenNewTerminalWindowAsync(LaunchCommand launchCommand) 
    {
        return OpenNewTerminalWindowAsync<RemoteTerminalStreamProvider>(launchCommand);
    }

    public static async Task<RemoteTerminal> OpenNewTerminalWindowAsync<TStreamProvider>(LaunchCommand launchCommand) where TStreamProvider : ITerminalStreamProvider
    {
        // todo generate unique terminalId
        int terminalId = 0;
        RemoteTerminal remoteTerminal = await RemoteTerminal.CreateAsync(terminalId, launchCommand).ConfigureAwait(false);
        TStreamProvider terminalStreamProvider = (TStreamProvider) typeof(TStreamProvider).GetMethod("CreateStandardStreamProvider").Invoke(null, [remoteTerminal]);

        terminalStreamProvider.AcquireStandardStreams();
        
        return remoteTerminal;
    }
}