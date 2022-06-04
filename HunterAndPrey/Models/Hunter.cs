using System;

namespace HunterAndPrey.Models
{
    public class Hunter : Cell
    {
        public Hunter()
        {
            Content = "[H]";
            Color = ConsoleColor.Green;
        }
    }
}