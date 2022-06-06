using System;

namespace HunterAndPrey.Models.States.Hunter
{
    public class MoveToRandomPositionState : State
    {
        public MoveToRandomPositionState(Board board) : base(board)
        {
        }

        public override bool CanEnter()
        {
            return false;
        }

        public override void Enter()
        {
            Console.WriteLine("Hunter andou para uma posição randomica");
            throw new System.NotImplementedException();
        }
    }
}