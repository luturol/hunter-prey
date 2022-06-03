using System;
using HunterAndPrey.Models;

namespace HunterAndPrey
{
    public class Game
    {
        private Cell[][] Board;

        public void Start()
        {
            var hunter = new Hunter();
            Console.WriteLine("Começou o jogo");
        }           
    }
}