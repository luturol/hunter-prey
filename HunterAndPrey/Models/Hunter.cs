using System;
using HunterAndPrey.Enums;

namespace HunterAndPrey.Models
{
    public class Hunter : Cell
    {
        private Direction _direction;
        public Direction FacingDirection
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;

                Color = HunterColor(FacingDirection);
            }
        }

        public Hunter()
        {
            Content = "[H]";
        }

        private ConsoleColor HunterColor(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return ConsoleColor.Blue;
                case Direction.NorthEast:
                    return ConsoleColor.Cyan;
                case Direction.Northwest:
                    return ConsoleColor.Gray;
                case Direction.East:
                    return ConsoleColor.Green;
                case Direction.West:
                    return ConsoleColor.Magenta;
                case Direction.South:
                    return ConsoleColor.Red;
                case Direction.Southeast:
                    return ConsoleColor.Black;
                case Direction.SouthWest:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.Yellow;
            }
        }
    }
}