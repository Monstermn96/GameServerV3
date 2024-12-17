using GameServerV3.Entities;
using GameServerV3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServerV3.Utils.Managers
{
    public class GameStateManager
    {
        private IGameState _gameState;
        public GameStateManager(IGameState gameState)
        {
            _gameState = gameState;
        }
        public void AddPlayer(Player player)
        {
            _gameState.AddPlayer(player);
        }
        public void RemovePlayer(Player player)
        {
            _gameState.RemovePlayer(player);
        }
    }
}
