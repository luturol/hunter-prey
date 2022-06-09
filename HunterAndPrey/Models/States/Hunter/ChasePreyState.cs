using System;
using System.Linq;

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

            var range = _board.GetRange(-5, 5, -5, 5, _board.Hunter.X, _board.Hunter.Y);

            if(range.Any(cell => cell is Models.Prey))
            {

            }
            //Calcular Path para o mais próximo com A*            
            //Verifica se precisa rotacionar
            //Se rotacionar, gira e termina o turno do hunter
            //Se não, se move em direção ao target
        }
    }
}