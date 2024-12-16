using GameServerV3.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace GameServerV3.Utils
{
    public class ClientManager : IClientManager
    {
        private readonly ILogger logger;

        public ClientManager(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task ManageClientAsync(TcpClient client)
        {
            var endpoint = client.Client.RemoteEndPoint.ToString();
            logger.Log($"Client connected: {endpoint}");

            try
            {
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8);
                while (true)
                {
                    string message = await reader.ReadLineAsync();
                    if (message == null) break;
                    logger.Log($"Received from {endpoint}: {message}");
                }
            }
            catch (Exception ex)
            {
                logger.Log("Client error: " + ex.Message);
            }
            finally
            {
                logger.Log($"Client disconnected: {endpoint}");
                client.Close();
            }
        }
    }
}