using System.Net.Sockets;

namespace GameServerV3.Interfaces
{
    public interface IClientManager
    {
        Task ManageClientAsync(TcpClient client);
        Task SendMessageAsync(string message);
    }
}