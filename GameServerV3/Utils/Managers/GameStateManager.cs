using GameServerV3.Entities;
using GameServerV3.Interfaces;
using GameServerV3.Interfaces.Manager;
using Newtonsoft.Json; // Ensure Newtonsoft.Json is referenced

namespace GameServerV3.Utils.Managers
{
    public class GameStateManager : IGameStateManager
    {
        private readonly IGameState gameState;

        public GameStateManager(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void AddPlayer(string userName, Player player)
        {
            if (!gameState.PlayerList.ContainsKey(userName))
            {
                gameState.PlayerList.Add(userName, player);
            }
        }

        public void AddBullet(Bullet bullet)
        {
            gameState.BulletList.Add(bullet);
        }

        public string GetSerializedGameState()
        {
            // Serialize the game state into a JSON string
            return JsonConvert.SerializeObject(gameState); // Pretty-print JSON for readability
        }
    }
}
