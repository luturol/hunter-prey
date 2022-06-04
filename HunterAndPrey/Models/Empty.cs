using System;

namespace HunterAndPrey.Models
{
    public class Empty : Cell
    {
        public Empty()
        {
            Content = "[-]";
            Color = ConsoleColor.White;
        }
    }
}