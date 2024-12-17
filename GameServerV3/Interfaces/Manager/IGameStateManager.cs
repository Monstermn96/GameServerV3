using GameServerV3.Entities;

namespace GameServerV3.Interfaces.Manager
{
    public interface IGameStateManager
    {
        void AddPlayer(string userName, Player player);
        void AddBullet(Bullet bullet);
    }
}