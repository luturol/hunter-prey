using System;

namespace HunterAndPrey.Models.States.Hunter
{
    public class ChasePreyState : State
    {
        public ChasePreyState(Board board) : base(board)
        {
        }
        
        public override bool CanEnter()
        {
            return false;
        }

        public override void Enter()
        {
            Console.WriteLine("Hunter está perseguindo uma presa");
            throw new System.NotImplementedException();
        }
    }
}