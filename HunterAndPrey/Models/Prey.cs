using System;
using HunterAndPrey.Enums;

namespace HunterAndPrey.Models
{
    public class Prey : Cell
    {
        public Direction FacingDirection { get; set; }
        
        public Prey()
        {
            Content = "[P]";
            Color = ConsoleColor.Cyan;
        }
    }
}