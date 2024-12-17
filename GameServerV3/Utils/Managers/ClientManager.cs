using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Xml;
using GameServerV3.Entities;
using GameServerV3.Interfaces;
using GameServerV3.Interfaces.Manager;
using Newtonsoft.Json;

public class ClientManager : IClientManager
{
    private readonly ILogger logger;
    private readonly IGameStateManager gameStateManager;
    private readonly INetworkManager networkManager;

    public ClientManager(ILogger logger, IGameStateManager gameStateManager, INetworkManager networkManager)
    {
        this.logger = logger;
        this.gameStateManager = gameStateManager;
        this.networkManager = networkManager;
    }

    public async Task ManageClientAsync(TcpClient client)
    {
        try
        {
            using var stream = client.GetStream();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            logger.Log($"Client handler started for {client.Client.RemoteEndPoint}.");

            string message;
            while ((message = await reader.ReadLineAsync()) != null)
            {
                logger.Log($"Received: {message}");

                try
                {
                    var jsonData = JsonConvert.DeserializeObject<dynamic>(message);
                    var type = jsonData.Type;
                    if (type == "Player")
                    {
                        var player = JsonConvert.DeserializeObject<Player>(message);
                        gameStateManager.AddPlayer(player.UserName, player);
                        logger.Log($"Player Added: {player.UserName}");
                        networkManager.BroadcastJsonMessageAsync(player);
                    }
                    if (type == "Bullet")
                    {
                        var bullet = JsonConvert.DeserializeObject<Bullet>(message);
                        gameStateManager.AddBullet(bullet);

                        networkManager.BroadcastJsonMessageAsync(bullet);
                        logger.Log($"BULLET ADDED TO STATE");
                    }

                    
                }
                catch (Newtonsoft.Json.JsonException)
                {
                    logger.Log("Invalid JSON received: " + message);
                }
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Client connection error: {ex.Message}");
        }
        finally
        {
            logger.Log("Client disconnected.");
            client.Close();
        }
    }
}