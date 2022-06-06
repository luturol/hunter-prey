using System;
using System.Linq;
using HunterAndPrey.Models;
using HunterAndPrey.Models.States;

namespace HunterAndPrey
{
    public class Game
    {
        /// <summary>
        /// Inicia o Jogo
        /// </summary>
        public void Start()
        {            
            Console.WriteLine("Começou o jogo");

            var board = new Board(GetRandomNumberOfPreys(), 30, 30);

            Hunter hunter = board.Hunter;
            
            int rounds = 0;
            bool hasEnded = false;

            var hunterMachine = new HunterMachine(board);

            // while (!hasEnded)
            // {
                //Reset board empty cells
                board.ResetEmptyCells();

                rounds++;
                Console.WriteLine("Round: " + rounds);
                

                var totalPreysAlive = board.GetTotalPreys();

                Console.WriteLine("Quantidade de presas vivas: " + totalPreysAlive);
                
                hunterMachine.Play();

                board.PrintBoard();

                if(board.GetTotalPreys() == 0)
                    hasEnded = true;                
            // }

            Console.WriteLine("Encerrou o jogo. O Caçador capturou todas as presas em " + rounds + " rounds");

        }

        /// <summary>
        /// Gera um número randômico de Presas
        /// </summary>
        /// <returns></returns>
        public int GetRandomNumberOfPreys() => new Random().Next(5, 10);
    }
}