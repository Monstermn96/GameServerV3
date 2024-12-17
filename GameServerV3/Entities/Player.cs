﻿using Newtonsoft.Json;

namespace GameServerV3.Entities
{
    public class Player
    {
        [JsonProperty("Type")]
        public string Type = "Player";

        [JsonProperty("UserName")]
        public string UserName { get; private set; }
        [JsonProperty("Color")]
        public Color Color { get; private set; }
        [JsonProperty("Position")]
        public PointF Position { get; set; }
        [JsonProperty("MovementSpeed")]
        public const float MovementSpeed = 5f;

        public Player(string userName, Color color, PointF initialPosition)
        {
            UserName = userName;
            Color = color;
            Position = initialPosition;
        }
    }
}
