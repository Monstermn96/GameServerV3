using System.Net.Sockets;

namespace GameServerV3.Interfaces.Manager
{
    public interface IClientManager
    {
        Task ManageClientAsync(TcpClient client);
    }
}