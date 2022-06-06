namespace HunterAndPrey.Models.States
{
    public abstract class State
    {
        protected State _previous;

        protected Board _board;

        public State(Board board)
        {
            _board = board;
        }

        public abstract bool CanEnter();        
        public abstract void Enter();
    }
}