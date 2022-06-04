using System;
using HunterAndPrey.Models;

namespace HunterAndPrey
{
    public class Game
    {        
        /// <summary>
        /// Inicia o Jogo
        /// </summary>
        public void Start()
        {
            var hunter = new Hunter();
            Console.WriteLine("Começou o jogo");

            var board = new Board(GetRandomNumberOfPreys(), 30, 30);
            board.PrintBoard();
        }

        /// <summary>
        /// Gera um número randômico de Presas
        /// </summary>
        /// <returns></returns>
        public int GetRandomNumberOfPreys() => new Random().Next(5, 10);        

        
    }
}