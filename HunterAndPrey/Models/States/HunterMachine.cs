using System;
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
            _board = board;

            _states = new List<State>()
            {
                new ChasePreyState(),
                new KillPreyState(),
                new MoveToRandomPositionState()
            };
        }

        public void Play()
        {
            var hunter = _board.Hunter;
            var range = _board.GetRange(-5, 5, -5, 5, hunter.X, hunter.Y);

            foreach(Cell cell in range)
            {
                if(cell is Empty)
                {
                    ((Empty) cell).SetColor(ConsoleColor.Green);
                }
            }            
        }
    }
}