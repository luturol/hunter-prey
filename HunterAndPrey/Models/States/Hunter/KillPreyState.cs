using System;
using System.Linq;

namespace HunterAndPrey.Models.States.Hunter
{
    public class KillPreyState : State
    {
        public KillPreyState(Board board) : base(board)
        {
        }

        public override bool CanEnter()
        {
            var neighbours = _board.GetNeighbours(_board.Hunter.X, _board.Hunter.Y);
                        
           return neighbours.Any(cell => cell is Models.Prey);            
        }

        public override void Enter()
        {
            Console.WriteLine("Hunter matou uma Prey");
            var neighbours = _board.GetNeighbours(_board.Hunter.X, _board.Hunter.Y);
            
            if (neighbours.Any(cell => cell is Models.Prey))
            {            
                _board.KillPrey(neighbours.First(cell => cell is Models.Prey));
            }
        }
    }
}