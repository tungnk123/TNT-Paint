using Microsoft.AspNetCore.SignalR.Client;
using System.IO.Pipes;

namespace SignalR
{
    class Program
    {
        private static HubConnection hubConnection;
        private static string pipeNameReceive;
        private static string pipeNameSend;

        static async Task Main(string[] args)
        {
            string uuid = Guid.NewGuid().ToString();
            pipeNameReceive = $"SignalRPipeReceive-{uuid}";
            pipeNameSend = $"SignalRPipeSend-{uuid}";

            WritePipeNames(pipeNameReceive, pipeNameSend);

            // Setup SignalR client
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7184/paintHub")
                .Build();

            hubConnection.On<byte[]>("ReceiveDrawing", data =>
            {
                Console.WriteLine("Received drawing data from hub");
                // Send received data to .NET 4.7.2 application
                SendToPipe(data);
            });

            hubConnection.On<string>("UserConnected", data =>
            {
                Console.WriteLine(data);
                // Send received data to .NET 4.7.2 application
            });

            await hubConnection.StartAsync();
            Console.WriteLine("Connected to SignalR hub");

            // Setup named pipes
            var pipeServerReceive = new NamedPipeServerStream(pipeNameReceive, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            var pipeServerSend = new NamedPipeClientStream(".", pipeNameSend, PipeDirection.Out);

            Console.WriteLine("Named Pipe Server is waiting for connection...");

            await pipeServerReceive.WaitForConnectionAsync();
            await pipeServerSend.ConnectAsync();

            Console.WriteLine("Client connected.");

            await Task.WhenAll(ListenToPipe(pipeServerReceive), Task.CompletedTask);
        }

        private static void WritePipeNames(string receivePipe, string sendPipe)
        {
            // add a file at .exe location with the pipe names
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pipeNames.txt");
            File.WriteAllText(path, $"{receivePipe}{Environment.NewLine}{sendPipe}");
        }


        private static async Task ListenToPipe(NamedPipeServerStream pipeServerReceive)
        {
            var buffer = new byte[256];

            while (true)
            {
                int bytesRead = await pipeServerReceive.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) continue;

                byte[] drawingData = new byte[bytesRead];
                Array.Copy(buffer, drawingData, bytesRead);

                Console.WriteLine("Received drawing data from .NET 4.7.2");

                // Send to SignalR hub
                await hubConnection.InvokeAsync("BroadcastDrawing", drawingData);
            }

            pipeServerReceive.Disconnect();
            pipeServerReceive.Dispose();
        }

        private static async void SendToPipe(byte[] data)
        {
            using var pipeServerSend = new NamedPipeClientStream(".", pipeNameSend, PipeDirection.Out);
            await pipeServerSend.ConnectAsync();
            await pipeServerSend.WriteAsync(data, 0, data.Length);
        }
    }

}