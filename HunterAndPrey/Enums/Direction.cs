using System;

namespace HunterAndPrey.Enums
{
    public enum Direction
    {
        North = 0,
        NorthEast = 1,
        Northwest = 2,
        East = 3,
        West = 4,
        South = 5,
        Southeast = 6,
        SouthWest = 7
    }

    public static class DirectionHelper
    {
        public static Direction Random() => (Direction)new Random().Next(0, Enum.GetNames(typeof(Direction)).Length);

        public static Direction GetDirectionFromOnCellToAnother(int x1, int y1, int x2, int y2)        
        {
            if (x2 < x1 && y2 < y1)
            {
                //olhando diagonal superior esquerda
                return Direction.Northwest;
            }
            else if (x2 > x1 && y2 < y1)
            {
                //olhando diagonal superior direita
                return Direction.NorthEast;
            }
            else if (x2 == x1 && y2 < y1)
            {
                //olhando para cima
                return Direction.North;
            }
            else if (x2 < x1 && y2 == y1)
            {
                //olhando para esquerda
                return Direction.West;
            }
            else if (x2 > x1 && y2 == y1)
            {
                //olhando para direita
                return Direction.East;
            }
            else if (x2 < x1 && y2 > y1)
            {
                //olhando para diagonal inferior esquerda
                return Direction.SouthWest;
            }
            else if (x2 > x1 && y2 > y1)
            {
                //olhando para diagonal inferior direita
                return Direction.Southeast;
            }
            else if (x2 == x1 && y2 > y1)
            {
                //olhando para diagonal inferior direita
                return Direction.South;
            }
            else
            {
                return Direction.North;
            }
        }

        public static ConsoleColor Color(Direction direction)
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