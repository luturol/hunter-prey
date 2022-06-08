using System;

namespace HunterAndPrey.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Valida se a posição informada é válida
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool IsValidPosition(this Array array, int x, int y) => x >= 0 && x < array.GetLength(1) && y >= 0 && y < array.GetLength(0);
    }
}