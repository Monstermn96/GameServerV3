using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServerV3.Interfaces;

namespace GameServerV3.Entities
{
    public class GameState : IGameState
    {
        public Dictionary<string, Player> PlayerList { get; set; }
        public GameState(Dictionary<string, Player> playerList)
        {
            PlayerList = playerList;
        }
        public void AddPlayer(string playerID)
        {
            PlayerList.Add(player, player.Position);
        }
        public void RemovePlayer(string playerID)
        {
            PlayerList.Remove(player);
        }
        public PointF GetPlayerPosition(string playerID)
        {
            return PlayerList[player];
        }
        public Player getPlayerByName(string name)
        {
            foreach (KeyValuePair<string, Player> playerID in PlayerList)
            {
                if (player.Key.Name == name)
                {
                    return player.Key;
                }
            }
            return null;
        }

    }
}   
