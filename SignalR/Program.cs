using Microsoft.AspNetCore.SignalR.Client;
using System.IO.Pipes;

namespace SignalR
{
    class Program
    {
        private static HubConnection hubConnection;

        static async Task Main(string[] args)
        {
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

            await hubConnection.StartAsync();
            Console.WriteLine("Connected to SignalR hub");

            // Setup named pipes
            var pipeServerReceive = new NamedPipeServerStream("SignalRPipeReceive", PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            var pipeServerSend = new NamedPipeClientStream(".", "SignalRPipeSend", PipeDirection.Out);

            Console.WriteLine("Named Pipe Server is waiting for connection...");

            await pipeServerReceive.WaitForConnectionAsync();
            await pipeServerSend.ConnectAsync();

            Console.WriteLine("Client connected.");

            await Task.WhenAll(ListenToPipe(pipeServerReceive), Task.CompletedTask);
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
            using var pipeServerSend = new NamedPipeClientStream(".", "SignalRPipeSend", PipeDirection.Out);
            await pipeServerSend.ConnectAsync();
            await pipeServerSend.WriteAsync(data, 0, data.Length);
        }
    }

}