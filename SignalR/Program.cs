using Microsoft.AspNetCore.SignalR.Client;
using System.IO.Pipes;
using System.Text;

namespace SignalR
{
    class Program
    {
        private static HubConnection hubConnection;
        private static string pipeNameReceive;
        private static string pipeNameSend;
        // Setup named pipes
        static NamedPipeServerStream pipeServerReceive;

        static async Task Main(string[] args)
        {
            string uuid = Guid.NewGuid().ToString();
            pipeNameReceive = $"SignalRPipeReceive-{uuid}";
            pipeNameSend = $"SignalRPipeSend-{uuid}";

            WritePipeNames(pipeNameReceive, pipeNameSend);

            pipeServerReceive = new NamedPipeServerStream(pipeNameReceive, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            // Setup SignalR client
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7184/paintHub")
                .Build();

            hubConnection.On<string>("ReceiveDrawing", data =>
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


            Console.WriteLine("Named Pipe Server is waiting for connection...");

            await pipeServerReceive.WaitForConnectionAsync();

            Console.WriteLine("Client connected.");

            await Task.WhenAll(ListenToPipe(pipeServerReceive), Task.CompletedTask);
            // Keep the application running
            Console.WriteLine("program is ending...");
            await Task.Delay(Timeout.Infinite);
        }

        private static void WritePipeNames(string receivePipe, string sendPipe)
        {
            // add a file at .exe location with the pipe names
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pipeNames.txt");
            File.WriteAllText(path, $"{receivePipe}{Environment.NewLine}{sendPipe}");
        }

        private static async Task ListenToPipe(NamedPipeServerStream pipeServerReceive)
        {
            using (var streamReader = new StreamReader(pipeServerReceive, Encoding.UTF8))
            {
                while (true)
                {
                    string receivedBase64 = await streamReader.ReadLineAsync();
                    if (string.IsNullOrEmpty(receivedBase64)) continue;

                    Console.WriteLine("Received Base64 data from .NET 4.7.2");

                    // Send to SignalR hub
                    await hubConnection.InvokeAsync("BroadcastDrawing", receivedBase64);
                }
            }

            pipeServerReceive.Disconnect();
            pipeServerReceive.Dispose();
        }

        private static async void SendToPipe(string data)
        {
            try
            {
                // Mỗi lần gửi dữ liệu, tạo một NamedPipeClientStream mới
                using (var pipeServerSend = new NamedPipeClientStream(".", pipeNameSend, PipeDirection.Out, PipeOptions.Asynchronous))
                {
                    await pipeServerSend.ConnectAsync();

                    using (var streamWriter = new StreamWriter(pipeServerSend, Encoding.UTF8))
                    {
                        await streamWriter.WriteLineAsync(data);
                        await streamWriter.FlushAsync();
                    }

                    // Print the data sent
                    Console.WriteLine("Data sent to pipe successfully: " + data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data to pipe: {ex.Message}");
            }
        }
    }
}
