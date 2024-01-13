using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Threading.Tasks;
using Nerdbank.Streams;
using StreamJsonRpc;

class Program
{
    static bool useStdIo = true;

    static async Task Main()
    {
        if (useStdIo)
        {
            ProcessStartInfo psi = new ProcessStartInfo(FindPathToServer(), "stdio")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process? process = Process.Start(psi);
            Stream stdioStream = FullDuplexStream.Splice(process.StandardOutput.BaseStream, process.StandardInput.BaseStream);
            await ActAsRpcClientAsync(stdioStream);
        }
        else
        {
            Console.WriteLine("Connecting to server...");
            await using NamedPipeClientStream stream = new NamedPipeClientStream(".", "StreamJsonRpcSamplePipe", PipeDirection.InOut, PipeOptions.Asynchronous);
            await stream.ConnectAsync();
            await ActAsRpcClientAsync(stream);
            Console.WriteLine("Terminating stream...");
        }
    }

    private static async Task ActAsRpcClientAsync(Stream stream)
    {
        Console.WriteLine("Connected. Sending request...");
        using var jsonRpc = JsonRpc.Attach(stream);
        int sum = await jsonRpc.InvokeAsync<int>("Add", 3, 5);
        Console.WriteLine($"3 + 5 = {sum}");
    }

    private static string FindPathToServer()
    {
        return "/home/mourita/Documents/programmieren/repos/AdvancedConsoles/TestClient/bin/Debug/net8.0/TestClient";
    }
}