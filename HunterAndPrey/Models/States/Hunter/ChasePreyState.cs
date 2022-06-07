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

            //Calcular Path para o mais próximo com A*            
            //Verifica se precisa rotacionar
            //Se rotacionar, gira e termina o turno do hunter
            //Se não, se move em direção ao target
        }
    }
}