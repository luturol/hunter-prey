using System.Collections.Generic;
using HunterAndPrey.Models.States.Hunter;

namespace HunterAndPrey.Models.States
{
    public class HunterMachine
    {
        private List<State> _states;
        private Board _board;
        
        public HunterMachine(Board board)
        {
            _states = new List<State>()
            {
                new ChasePreyState(),
                new KillPreyState(),
                new MoveToRandomPositionState()
            };
        }
    }
}