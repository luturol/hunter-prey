namespace HunterAndPrey.Models.States
{
    public abstract class State
    {
        protected Board _board;

        public State(Board board)
        {
            _board = board;
        }

        public abstract bool CanEnter();        
        public abstract void Enter();
    }
}