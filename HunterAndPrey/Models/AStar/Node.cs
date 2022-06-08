namespace HunterAndPrey.Models.AStar
{
    /// <summary>
    /// Nodo da Grid utilizada para calcular o Path do algoritmo A*
    /// </summary>
    public class Node
    {
        public int GridX { get; private set; }
        public int GridY { get; private set; }
        public Node parent { get; set; }

        /// <summary>
        /// Goal Distance
        /// </summary>
        /// <value></value>
        public int gCost { get; set; }

        /// <summary>
        /// Heuristic Distance
        /// </summary>
        /// <value></value>
        public int hCost { get; set; }

        /// <summary>
        /// Custo total para se mover
        /// </summary>
        /// <value></value>
        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public Node(int gridX, int gridY)
        {
            GridX = gridX;
            GridY = gridY;
        }
    }
}