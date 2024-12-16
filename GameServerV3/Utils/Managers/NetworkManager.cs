using GameServerV3.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace GameServerV3.Utils.Managers
{
    public class NetworkManager : INetworkManager
    {
        private readonly ILogger logger;
        private readonly Func<IClientManager> clientHandlerFactory;
        private TcpListener server;
        private bool isServerRunning = false;

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
                var handler = clientHandlerFactory();
                _ = handler.ManageClientAsync(client);
            }
        }
    }
}