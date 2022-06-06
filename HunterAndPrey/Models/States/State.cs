namespace HunterAndPrey.Models.States
{
    public abstract class State
    {
        protected State _previous;
        protected abstract bool CanEnter();        
    }
}