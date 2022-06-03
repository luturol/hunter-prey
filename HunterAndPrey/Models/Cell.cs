namespace HunterAndPrey.Models
{
    public abstract class Cell
    {
        public virtual string Content { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }        
    }
}