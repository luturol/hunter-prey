using System;
using System.Linq;
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
            Console.WriteLine("Começou o jogo");

            var board = new Board(GetRandomNumberOfPreys(), 30, 30);

            Hunter hunter = board.Hunter;
            
            int rounds = 0;
            bool hasEnded = false;

            // while (!hasEnded)
            // {
                rounds++;
                Console.WriteLine("Round: " + rounds);
                board.PrintBoard();

                var totalPreysAlive = board.GetTotalPreys();

                Console.WriteLine("Quantidade de presas vivas: " + totalPreysAlive);
                
                //Verifica se tem uma Prey adjacente ao Hunter
                var neighbours = board.GetNeighbours(hunter.X, hunter.Y);
                //Se há, então elimina a Prey
                if(neighbours.Any(cell => cell is Prey))
                {
                    //Elimina Prey
                }
                //Se não
                //Verificar se há alguma Prey na range do Hunter
                
                //Mover Hunter

                //Mover Preys

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