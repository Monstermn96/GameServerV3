using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Xml;
using GameServerV3.Interfaces;
using Newtonsoft.Json;

public class ClientManager : IClientManager
{
    private readonly ILogger logger;

    public ClientManager(ILogger logger)
    {
        this.logger = logger;
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
                    logger.Log("Parsed JSON: " + JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented));
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
