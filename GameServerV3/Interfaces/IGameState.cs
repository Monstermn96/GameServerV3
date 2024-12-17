using GameServerV3.Entities;

namespace GameServerV3.Interfaces
{
    public interface IGameState
    {
        public Dictionary<Player, PointF> PlayerList { get; set; }
    }
}