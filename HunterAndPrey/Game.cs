using System;
using System.Linq;
using System.Threading;
using HunterAndPrey.Enums;
using HunterAndPrey.Models;
using HunterAndPrey.Models.AStar;
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
            Console.WriteLine("Informe o tempo em milissegundos entre rounds:");
            var time = Console.ReadLine();

            int timeMilisseconds;
            if (!int.TryParse(time, out timeMilisseconds))
            {
                Console.WriteLine("Como não foi informado, será mantido o tempo default de 10s");
                timeMilisseconds = 10000;
            }

            Console.WriteLine("Começou o jogo");

            var board = new Board(GetRandomNumberOfPreys(), 30, 30);

            Hunter hunter = board.Hunter;

            int rounds = 0;
            bool hasEnded = false;

            var hunterMachine = new HunterMachine(board);
            var preyMachine = new PreyMachine(board);

            while (!hasEnded)
            {
                //Reset board empty cells
                board.ResetEmptyCells();

                rounds++;

                #region Legenda da Cor do Caçador
                Console.WriteLine("Legenda:");
                foreach (Direction direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
                {
                    Console.ForegroundColor = DirectionHelper.Color(direction);
                    Console.WriteLine(direction);
                }

                Console.ForegroundColor = ConsoleColor.White;
                #endregion Legenda da Cor do Caçador

                #region Round
                Console.WriteLine("Round: " + rounds);

                var totalPreysAlive = board.GetTotalPreys();

                Console.WriteLine("Quantidade de presas vivas: " + totalPreysAlive);

                hunterMachine.Play();
                preyMachine.Play();
                #endregion Round

                #region Mostrar resultado do round
                board.PrintBoard();

                var prey = board.GetPreys().First();

                if (board.GetTotalPreys() == 0)
                {
                    hasEnded = true;
                }
                #endregion Mostrar resultado do round

                Thread.Sleep(timeMilisseconds);
            }

            Console.WriteLine("Encerrou o jogo. O Caçador capturou todas as presas em " + rounds + " rounds");

        }

        /// <summary>
        /// Gera um número randômico de Presas
        /// </summary>
        /// <returns></returns>
        public int GetRandomNumberOfPreys() => new Random().Next(5, 10);

    }
}