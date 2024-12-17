namespace GameServerV3.Interfaces.Manager
{
    public interface INetworkManager
    {
        void StartServer();
        void StopServer();
        Task BroadcastJsonMessageAsync(object obj);
    }
}