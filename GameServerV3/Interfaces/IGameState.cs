using GameServerV3.Entities;

namespace GameServerV3.Interfaces
{
    public interface IGameState
    {
        Dictionary<string, Player> PlayerList { get; set; }
        List<Bullet> BulletList { get; set; }
    }
}