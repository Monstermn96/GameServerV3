using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServerV3.Entities
{
    public class Player
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public PointF Position { get; set; }
        public const float MovementSpeed = 5f;

        public Player(string name, Color color, PointF initialPosition)
        {
            Name = name;
            Color = color;
            Position = initialPosition;
        }
    }
}
