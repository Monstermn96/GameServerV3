using GameServerV3.Interfaces;
using GameServerV3.Interfaces.Manager;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameServerV3.Utils.Managers
{
    public class NetworkManager : INetworkManager
    {
        private readonly ILogger logger;
        private readonly Func<IClientManager> clientHandlerFactory;
        private TcpListener server;
        private bool isServerRunning = false;
        private readonly List<TcpClient> connectedClients = new List<TcpClient>();

        public NetworkManager(ILogger logger, Func<IClientManager> clientHandlerFactory)
        {
            this.logger = logger;
            this.clientHandlerFactory = clientHandlerFactory;
        }

        public void StartServer()
        {
            if (isServerRunning)
            {
                logger.Log("Server is already running.");
                return;
            }

            try
            {
                server = new TcpListener(IPAddress.Parse("192.168.50.184"), 5555);
                server.Start();
                isServerRunning = true;
                logger.Log("Server started.");
                _ = AcceptClientsAsync();
            }
            catch (Exception ex)
            {
                logger.Log("Error: " + ex.Message);
            }
        }

        public void StopServer()
        {
            if (!isServerRunning)
            {
                logger.Log("Server is not running.");
                return;
            }

            try
            {
                isServerRunning = false;
                server?.Stop();
                foreach (var client in connectedClients)
                {
                    client.Close();
                }
                connectedClients.Clear();
                logger.Log("Server stopped.");
            }
            catch (Exception ex)
            {
                logger.Log("Error stopping server: " + ex.Message);
            }
        }

        private async Task AcceptClientsAsync()
        {
            while (isServerRunning)
            {
                var client = await server.AcceptTcpClientAsync();
                connectedClients.Add(client);
                var handler = clientHandlerFactory();
                _ = handler.ManageClientAsync(client);
            }
        }

        public async Task BroadcastJsonMessageAsync(object obj)
        {
            string jsonMessage = JsonConvert.SerializeObject(obj);
            
            foreach (var client in connectedClients)
            {
                try
                {
                    if (client.Connected)
                    {
                        var writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };
                        await writer.WriteLineAsync(jsonMessage);
                        logger.Log($"Broadcasted: {jsonMessage}");
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Error sending message to client: {ex.Message}");
                }
            }
        }
    }
}
