using System;
using System.Linq;

namespace HunterAndPrey.Models.States.Prey
{
    public class MoveToRandomPositionState : State
    {
        private Cell _cell;

        public MoveToRandomPositionState(Board board, Cell cell) : base(board)
        {
            _cell = cell;
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Enter()
        {
            Console.WriteLine("Movendo presas");

            var neighbours = _board.GetNeighbours(_cell.X, _cell.Y).Where(cell => cell is Empty).ToList();

            var randomPos = neighbours[new Random().Next(0, neighbours.Count() - 1)];

            _board.MovePosition(_cell, randomPos.X, randomPos.Y);
        }
    }
}