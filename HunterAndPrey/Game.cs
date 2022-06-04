using System;
using HunterAndPrey.Models;

namespace HunterAndPrey
{
    public class Game
    {
        private Cell[,] Board;

        /// <summary>
        /// Inicia o Jogo
        /// </summary>
        public void Start()
        {
            var hunter = new Hunter();
            Console.WriteLine("Começou o jogo");

            Board = CreateBoard(GetRandomNumberOfPreys());
            PrintBoard();
        }

        /// <summary>
        /// Gera um número randômico de Presas
        /// </summary>
        /// <returns></returns>
        public int GetRandomNumberOfPreys() => new Random().Next(5, 10);

        /// <summary>
        /// Gera uma posição aleatória no Board de 0 à 30
        /// </summary>
        /// <param name="x"></param>
        /// <param name="GetRandomXAndY("></param>
        /// <returns></returns>
        public (int x, int y) GetRandomXAndY() => (new Random().Next(0, 30), new Random().Next(0, 30));

        /// <summary>
        /// Cria o Tabuleiro
        /// </summary>
        /// <param name="numberOfPreys"></param>
        /// <returns></returns>
        public Cell[,] CreateBoard(int numberOfPreys)
        {
            Cell[,] board = new Cell[30, 30];

            Console.WriteLine("Criando o Tabuleiro");

            //Populando presas
            Console.WriteLine($"Total de Presas = {numberOfPreys}");
            for (int i = 0; i < numberOfPreys; i++)
            {
                var prey = new Prey();

                bool setPreyOnBoard = false;
                while (setPreyOnBoard == false)
                {
                    (int randomX, int randomY) = GetRandomXAndY();

                    if (board[randomX, randomY] == null)
                    {
                        prey.X = randomX;
                        prey.Y = randomY;

                        board[randomY, randomX] = prey;
                        setPreyOnBoard = true;

                        Console.WriteLine($"Colocou Presa {i} na posição X = {randomX} e Y = {randomY}");
                    }
                }
            }

            //Populando Caçador
            Console.WriteLine("Colocando o Caçador");
            bool isHunterOnBoard = false;
            var hunter = new Hunter();
            while (isHunterOnBoard == false)
            {
                (int randomX, int randomY) = GetRandomXAndY();

                if (board[randomX, randomY] == null)
                {
                    hunter.X = randomX;
                    hunter.Y = randomY;

                    board[randomY, randomX] = hunter;
                    isHunterOnBoard = true;

                    Console.WriteLine($"Colocou Caçador na posição X = {randomX} e Y = {randomY}");
                }
            }

            Console.WriteLine("Populando com vazio o tabuleiro");
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (board[i, j] == null)
                    {
                        var emptyCell = new Empty();
                        board[i, j] = emptyCell;
                        emptyCell.X = j;
                        emptyCell.Y = i;
                    }
                }
            }

            return board;
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 30; i++)
            {
                string row = string.Empty;
                for (int j = 0; j < 30; j++)
                {
                    // row += Board[i, j].Content;
                    var cell = Board[i, j];
                    if (cell is Hunter)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (cell is Prey)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    Console.Write(Board[i, j].Content);
                }
                Console.WriteLine(row);
            }
        }
    }
}