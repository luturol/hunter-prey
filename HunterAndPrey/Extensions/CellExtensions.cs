using System;
using HunterAndPrey.Models;

namespace HunterAndPrey.Extensions
{
    public static class CellExtensions
    {
        /// <summary>
        /// Gera uma posição aleatória no Board de 0 à 30
        /// </summary>
        /// <param name="x"></param>
        /// <param name="GetRandomXAndY("></param>
        /// <returns></returns>
        public static (int x, int y) GetRandomXAndY(this Cell[,] board) => (new Random().Next(0, board.GetLength(0)), new Random().Next(0, board.GetLength(1)));
    }
}