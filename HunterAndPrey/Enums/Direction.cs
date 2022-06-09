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
    }
}