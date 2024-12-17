using GameServerV3.Entities;
using GameServerV3.Interfaces;
using Newtonsoft.Json;

namespace GameServerV3.Entities
{
    public class GameState : IGameState
    {
        [JsonProperty("PlayerList")]
        public Dictionary<string, Player> PlayerList { get; set; }

        [JsonProperty("BulletList")]
        public List<Bullet> BulletList { get; set; }

        public GameState()
        {
            PlayerList = new Dictionary<string, Player>();
            BulletList = new List<Bullet>();
        }
    }
}