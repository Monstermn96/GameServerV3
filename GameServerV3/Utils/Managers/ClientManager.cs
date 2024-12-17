using GameServerV3.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace GameServerV3.Utils.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly ILogger logger;
        private TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;
        private IGameState gameState;

        public ClientManager(ILogger logger, IGameState gameState)
        {
            this.logger = logger;
            this.gameState = gameState;
        }

        public async Task ManageClientAsync(TcpClient client)
        {
            this.client = client;
            var stream = client.GetStream();
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            var endpoint = client.Client.RemoteEndPoint.ToString();
            logger.Log($"Client connected: {endpoint}");

            try
            {
                while (client.Connected)
                {
                    string message = await reader.ReadLineAsync();
                    if (message == null) break;
                    // Handle "player" updates and broadcast back full state
                    if (message.StartsWith("player"))
                    {
                        
                        string[] parts = message.Split(',');
                        string playerName = parts[1];
                        float posX = float.Parse(parts[2]);
                        float posY = float.Parse(parts[3]);
                        if (gameState.PlayerList.TryGetValue()

                        {

                        }
                        // Send back updated state to all clients (example)
                        string fullState = $"player,{playerName},{posX},{posY}";
                        await writer.WriteLineAsync(fullState);
                        logger.Log($"Sent updated player state: {fullState}");
                    }

                    logger.Log($"Received from {endpoint}: {message}");

                    // Echo the message back or send a response
                    //await SendMessageAsync($"Echo: {message}");
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Client error: {ex.Message}");
            }
            finally
            {
                client.Close();
                logger.Log($"Client disconnected: {endpoint}");
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (client?.Connected == true && writer != null)
            {
                await writer.WriteLineAsync(message);
                logger.Log($"Sent to client: {message}");
            }
        }
    }
}
