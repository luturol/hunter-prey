namespace HunterAndPrey.Models
{
    /// <summary>
    /// Vetor de coordenadas X Y
    /// </summary>
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}