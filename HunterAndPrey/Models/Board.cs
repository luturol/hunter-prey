using System;
using System.Collections.Generic;
using System.Linq;
using HunterAndPrey.Enums;
using HunterAndPrey.Extensions;
using HunterAndPrey.Models.AStar;

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

            #region Populando presas
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
            #endregion Populando presas

            #region Populando Caçador
            Console.WriteLine("Colocando o Caçador");
            bool isHunterOnBoard = false;
            Hunter = new Hunter();

            var direction = (Direction)new Random().Next(1, 8);
            Hunter.FacingDirection = direction;

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
            #endregion Populando Caçador

            #region Populando com vazio
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
            #endregion Populando com vazio

            return board;
        }

        /// <summary>
        /// Imprime o tabuleiro no console
        /// </summary>
        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                string row = string.Empty;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    var cell = _board[i, j];

                    Console.ForegroundColor = cell.Color;

                    Console.Write(_board[i, j].Content);
                }
                Console.WriteLine(row);
            }
        }

        public void PrintBoard(List<Node> path)
        {
            Console.WriteLine();
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                string row = string.Empty;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (path.Any(e => e.GridX == j && e.GridY == i) && _board[i, j] is Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[*]");
                    }
                    else
                    {
                        var cell = _board[i, j];
                        Console.ForegroundColor = cell.Color;
                        Console.Write(_board[i, j].Content);
                    }

                    // row += Board[i, j].Content;

                }
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Move a cellToMove para a posição Y,X
        /// </summary>
        /// <param name="cellToMove"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePosition(Cell cellToMove, int x, int y)
        {
            var empty = new Empty();
            empty.X = cellToMove.X;
            empty.Y = cellToMove.Y;

            _board[cellToMove.Y, cellToMove.X] = empty;
            _board[y, x] = cellToMove;

            cellToMove.X = x;
            cellToMove.Y = y;
        }

        /// <summary>
        /// Pega células vizinhas
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<Cell> GetNeighbours(int x, int y)
        {
            return GetRange(-1, 1, -1, 1, x, y);
        }

        /// <summary>
        /// Mata a presa
        /// </summary>
        /// <param name="cell"></param>
        public void KillPrey(Cell cell)
        {
            var empty = new Empty();
            empty.X = cell.X;
            empty.Y = cell.Y;

            _board[cell.Y, cell.X] = empty;
        }

        /// <summary>
        /// Pega todas as células na range X,Y
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<Cell> GetRange(int minX, int maxX, int minY, int maxY, int x, int y)
        {
            List<Cell> neighbours = new();

            for (int xPos = minX; xPos <= maxX; xPos++)
            {
                for (int yPos = minY; yPos <= maxY; yPos++)
                {
                    if (xPos == 0 && yPos == 0)
                        continue;

                    int newX = x + xPos;
                    int newY = y + yPos;

                    if (_board.IsValidPosition(newX, newY))
                    {
                        neighbours.Add(_board[newY, newX]);
                    }
                }
            }

            return neighbours;
        }

        /// <summary>
        /// Reseta a cor das células vazias
        /// </summary>
        public void ResetEmptyCells()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    // row += Board[i, j].Content;
                    var cell = _board[i, j];

                    if (cell is Empty)
                    {
                        ((Empty)cell).SetColor(ConsoleColor.White);
                    }
                }
            }
        }

        /// <summary>
        /// Pega todas as Presas do Tabuleiro
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetPreys() => (from Cell cell in _board
                                         where cell is Prey
                                         select cell).ToList();

        /// <summary>
        /// Pega o total de presas
        /// </summary>
        /// <returns></returns>
        public int GetTotalPreys() => GetPreys().Count();

        /// <summary>
        /// Pega a Celula Y,X
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell GetCell(int x, int y)
        {
            if (_board.IsValidPosition(x, y))
                return _board[y, x];
            else
                return null;
        }
    }
}