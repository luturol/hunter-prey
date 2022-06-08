using System.Collections.Generic;
using HunterAndPrey.Extensions;

namespace HunterAndPrey.Models.AStar
{
    /// <summary>
    /// Grid usada para calcular o Path do algoritmo A*
    /// </summary>
    public class Grid
    {
        private Node[,] nodes;

        public List<Node> Path { get; set; }

        public Grid(int x, int y)
        {
            nodes = new Node[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    nodes[i, j] = new Node(j, i);
                }
            }
        }

        /// <summary>
        /// Pega o Nodo da posição informada por parâmetro
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Node GetPosition(Vector2 position)
        {
            if (nodes.IsValidPosition(position.X, position.Y))
            {
                return nodes[position.Y, position.X];
            }

            return null;
        }

        /// <summary>
        /// Pega os vizinhos do Nodo
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.GridX + x;
                    int checkY = node.GridY + y;

                    if (nodes.IsValidPosition(checkX, checkY))
                    {
                        neighbours.Add(nodes[checkY, checkX]);
                    }
                }
            }

            return neighbours;
        }
    }
}