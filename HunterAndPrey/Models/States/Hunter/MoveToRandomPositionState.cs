using System;
using System.Linq;

namespace HunterAndPrey.Models.States.Hunter
{
    public class MoveToRandomPositionState : State
    {
        public MoveToRandomPositionState(Board board) : base(board)
        {
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Enter()
        {
            Console.WriteLine("Hunter andou para uma posição randomica");
            
            var neighbours = _board.GetNeighbours(_board.Hunter.X, _board.Hunter.Y);

            var randomPos = neighbours[new Random().Next(0, neighbours.Count() - 1)];

            _board.MovePosition(_board.Hunter, randomPos.X, randomPos.Y);
        }
    }
}