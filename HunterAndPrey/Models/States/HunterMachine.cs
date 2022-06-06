using System;
using System.Collections.Generic;
using HunterAndPrey.Models.States.Hunter;

namespace HunterAndPrey.Models.States
{
    public class HunterMachine
    {
        private List<State> _states;
        private Board _board;

        private ChasePreyState _chasePreyState;
        private KillPreyState _killPreyState;
        private MoveToRandomPositionState _moveToRandomPos;

        public HunterMachine(Board board)
        {
            _board = board;

            _chasePreyState = new ChasePreyState(_board);
            _killPreyState = new KillPreyState(_board);
            _moveToRandomPos = new MoveToRandomPositionState(_board);
        }

        public void Play()
        {
            var hunter = _board.Hunter;
            var range = _board.GetRange(-5, 5, -5, 5, hunter.X, hunter.Y);

            foreach (Cell cell in range)
            {
                if (cell is Empty)
                {
                    ((Empty)cell).SetColor(ConsoleColor.Green);
                }
            }

            if (_killPreyState.CanEnter())
            {
                _killPreyState.Enter();
            }
            else if(_chasePreyState.CanEnter())
            {
                _chasePreyState.Enter();
            }
            else if(_moveToRandomPos.CanEnter())
            {
                _moveToRandomPos.Enter();
            }
        }        
    }
}