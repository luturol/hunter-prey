using System;
using System.Collections.Generic;

namespace HunterAndPrey.Models.AStar
{
    /// <summary>
    /// Classe utilizada para calcular o caminho para o algoritmo A*
    /// </summary>
    public class Path
    {
        private Grid _grid;

        public Path(Grid grid)
        {
            _grid = grid;
        }

        /// <summary>
        /// Procura o caminho entre dois pontos
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        public void FindPath(Vector2 startPosition, Vector2 endPosition)
        {
            Node startNode = _grid.GetPosition(startPosition);
            Node endNode = _grid.GetPosition(endPosition);

            List<Node> openSet = new();
            HashSet<Node> closeSet = new();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost < currentNode.fCost ||
                        openSet[i].fCost == currentNode.fCost &&
                        openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closeSet.Add(currentNode);

                //Encontrou o destino, popula o Grid.Path com o caminho até ele
                if (currentNode == endNode)
                {
                    RetracePath(startNode, endNode);
                }

                //Calcula a distância para se mover para os nodos vizinhos e adiciona o caminho anterior no Parent caso o caminho passe por ele
                foreach (Node neighbour in _grid.GetNeighbours(currentNode))
                {
                    if (closeSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int movementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);

                    if (movementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = movementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, endNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Faz o caminho de volta para o Nodo e popula o Grid.Path
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        private void RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }

            path.Reverse();

            _grid.Path = path;
        }

        ///<sumary>
        /// Count on X axis and Y axis how many node we are from the target node
        /// On Y we get how many diagnoals moves we are from target node
        /// On X we get how many horizontal moves we are from target node
        /// Subtract lowest number from higher to find how many horizontal moves we are from target
        /// Equation: 14y + 10(x - y)
        ///</sumary>
        int GetDistance(Node nodeA, Node nodeB)
        {
            int distX = Math.Abs(nodeA.GridX - nodeB.GridX);
            int distY = Math.Abs(nodeA.GridY - nodeB.GridY);

            if (distX > distY)
                return 14 * distY + 10 * (distX - distY);
            else
                return 14 * distX + 10 * (distY - distX);
        }
    }
}