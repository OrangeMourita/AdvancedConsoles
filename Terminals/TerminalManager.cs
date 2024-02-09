using System.Collections.ObjectModel;
using Terminals.Emulators;
using Terminals.StreamProviding;
using Terminals.StreamProviding.Providers;
using Terminals.Types;

namespace Terminals;

public static class TerminalManager
{
    private static RootTerminal _rootTerminal;
    
    static TerminalManager()
    {
        InitializeMainTerminal();
    }

    private static Collection<Terminal> AvailableTerminals { get; set; } = [];

    public static RootTerminal RootTerminal
    {
        get => _rootTerminal;
        private set
        {
            _rootTerminal = value;
            AvailableTerminals.Insert(0, RootTerminal);
        } 
    }


    
    
    private static void InitializeMainTerminal()
    {
        RootTerminal rootTerminal = new RootTerminal()
        {
            ProcessId = Environment.ProcessId
        };
        
        ITerminalStreamProvider terminalStreamProvider = RootTerminalStreamProvider.CreateStandardStreamProvider(rootTerminal);;
        terminalStreamProvider.AcquireStandardStreams();

        RootTerminal = rootTerminal;
    }
    
    
    /// <summary>
    /// Initializes the <see cref="RootTerminal"/> (again) with a custom <see cref="ITerminalStreamProvider"/>.
    /// This method method is slower due to being reflection based.
    /// </summary>
    /// <typeparam name="TStreamProvider"></typeparam>
    public static RootTerminal InitializeMainTerminal<TStreamProvider>() where TStreamProvider : ITerminalStreamProvider
    {
        RootTerminal rootTerminal = new RootTerminal();
        TStreamProvider terminalStreamProvider = (TStreamProvider) typeof(TStreamProvider).GetMethod("CreateStandardStreamProvider").Invoke(null, [rootTerminal]);
        terminalStreamProvider.AcquireStandardStreams();

        RootTerminal = rootTerminal;

        return RootTerminal;
    }

    
    public static Task<ChildTerminal> OpenNewTerminalWindowAsync(TerminalEmulator terminalEmulator)
    {
        return OpenNewTerminalWindowAsync(terminalEmulator.GetLaunchCommand());
    }
    
    public static Task<ChildTerminal> OpenNewTerminalWindowAsync<TStreamProvider>(TerminalEmulator terminalEmulator) where TStreamProvider : ITerminalStreamProvider
    {
        return OpenNewTerminalWindowAsync<TStreamProvider>(terminalEmulator.GetLaunchCommand());
    }
    
    
    public static Task<ChildTerminal> OpenNewTerminalWindowAsync(LaunchCommand launchCommand) 
    {
        return OpenNewTerminalWindowAsync<ChildTerminalStreamProvider>(launchCommand);
    }

    public static async Task<ChildTerminal> OpenNewTerminalWindowAsync<TStreamProvider>(LaunchCommand launchCommand) where TStreamProvider : ITerminalStreamProvider
    {
        // todo generate unique terminalId
        int terminalId = 0;
        ChildTerminal childTerminal = await ChildTerminal.CreateAsync(terminalId, launchCommand).ConfigureAwait(false);
        TStreamProvider terminalStreamProvider = (TStreamProvider) typeof(TStreamProvider).GetMethod("CreateStandardStreamProvider").Invoke(null, [childTerminal]);

        terminalStreamProvider.AcquireStandardStreams();
        
        return childTerminal;
    }
}