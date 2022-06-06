using HunterAndPrey.Models.States.Prey;

namespace HunterAndPrey.Models.States
{
    public class PreyMachine
    {
        private Board _board;

        public PreyMachine(Board board)
        {
            _board = board;
        }

        public void Play()
        {
            var preys = _board.GetPreys();

            foreach (Cell cell in preys)
            {
                new MoveToRandomPositionState(_board, cell).Enter();
            }
        }
    }
}