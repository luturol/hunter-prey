using System;
using System.Collections.Generic;
using System.Linq;
using HunterAndPrey.Extensions;

namespace HunterAndPrey.Models
{
    public class Board
    {
        private Cell[,] _board;

        public Hunter Hunter { get; private set; }
        public Board(int numberOfPreys, int xSize, int ySize)
        {
            _board = CreateBoard(numberOfPreys, xSize, ySize);
        }


        /// <summary>
        /// Cria o Tabuleiro
        /// </summary>
        /// <param name="numberOfPreys"></param>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <returns></returns>
        private Cell[,] CreateBoard(int numberOfPreys, int xSize, int ySize)
        {
            Cell[,] board = new Cell[ySize, xSize];

            Console.WriteLine("Criando o Tabuleiro");

            //Populando presas
            Console.WriteLine($"Total de Presas = {numberOfPreys}");
            for (int i = 0; i < numberOfPreys; i++)
            {
                var prey = new Prey();

                bool setPreyOnBoard = false;
                while (setPreyOnBoard == false)
                {
                    (int randomX, int randomY) = board.GetRandomXAndY();

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
            Hunter = new Hunter();
            while (isHunterOnBoard == false)
            {
                (int randomX, int randomY) = board.GetRandomXAndY();

                if (board[randomX, randomY] == null)
                {
                    Hunter.X = randomX;
                    Hunter.Y = randomY;

                    board[randomY, randomX] = Hunter;
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
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                string row = string.Empty;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    // row += Board[i, j].Content;
                    var cell = _board[i, j];
                    Console.ForegroundColor = cell.Color;
                    Console.Write(_board[i, j].Content);
                }
                Console.WriteLine(row);
            }
        }

        public void MovePosition(Cell cellToMove, int x, int y)
        {

        }

        public int GetTotalPreys() => (from Cell cell in _board
                                       where cell is Prey
                                       select cell).Count();

        public List<Cell> GetNeighbours(int x, int y)
        {
            List<Cell> neighbours = new();

            for (int xPos = -1; xPos <= 1; xPos++)
            {
                for (int yPos = -1; yPos <= 1; yPos++)
                {
                    if (xPos == 0 && yPos == 0)
                        continue;

                    int newX = x + xPos;
                    int newY = y + yPos;

                    if (newX >= 0 && newX < _board.GetLength(1) && newY >= 0 && newY < _board.GetLength(0))
                    {
                        neighbours.Add(_board[newY, newX]);
                    }
                }
            }

            return neighbours;
        }

        public void KillPrey(Cell cell)
        {
            var empty = new Empty();
            empty.X = cell.X;
            empty.Y = cell.Y;
            
            _board[cell.Y, cell.X] = empty;
        }
    }
}