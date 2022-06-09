using System;
using System.Linq;
using HunterAndPrey.Enums;
using HunterAndPrey.Models.AStar;

namespace HunterAndPrey.Models.States.Hunter
{
    /// <summary>
    /// Calcular Path para o mais próximo com A*            
    /// Verifica se precisa rotacionar
    /// Se rotacionar, gira e termina o turno do hunter
    /// Se não, se move em direção ao target
    /// </summary>
    public class ChasePreyState : State
    {
        public ChasePreyState(Board board) : base(board)
        {
        }

        public override bool CanEnter()
        {
            var range = _board.GetRange(-5, 5, -5, 5, _board.Hunter.X, _board.Hunter.Y);

            return range.Any(cell => cell is Models.Prey);
        }

        public override void Enter()
        {
            var range = _board.GetRange(-5, 5, -5, 5, _board.Hunter.X, _board.Hunter.Y);

            if (range.Any(cell => cell is Models.Prey))
            {
                Console.WriteLine("Caçador está perseguindo uma presa");

                //Cria grid para o A*
                Grid grid = new Grid(_board.XSize, _board.YSize);
                Path path = new Path(grid);

                //Pega a presa mais próxima com o menor Path pelo A*
                var nearstCell = range.Where(cell => cell is Models.Prey)
                    .OrderBy(cell =>
                    {
                        path.FindPath(new Vector2(_board.Hunter.X, _board.Hunter.Y), new Vector2(cell.X, cell.Y));
                        return grid.Path.Count;
                    })
                    .First();


                //Recalcula o Path até a presa mais próxima
                path.FindPath(new Vector2(_board.Hunter.X, _board.Hunter.Y), new Vector2(nearstCell.X, nearstCell.Y));

                #if DEBUG                
                Console.WriteLine("Imprimindo o tabuleiro com o Pathfinding calculado");
                _board.PrintBoard(grid.Path);
                #endif
                
                var pathToFollow = grid.Path;

                if (pathToFollow.Count > 0)
                {
                    var nextNode = pathToFollow[0];

                    var directionToNextCell = DirectionHelper.GetDirectionFromOnCellToAnother(_board.Hunter.X, _board.Hunter.Y, nextNode.GridX, nextNode.GridY);

                    if (directionToNextCell == _board.Hunter.FacingDirection)
                    {
                        Console.WriteLine("Caçador se moveu em direção para a presa. Direção do Caçador " + _board.Hunter.FacingDirection + " Direção que precisa andar para ir em direção a presa " + directionToNextCell);

                        _board.MovePosition(_board.Hunter, nextNode.GridX, nextNode.GridY);
                    }
                    else
                    {
                        Console.WriteLine("Caçador mudou de direção pra ir em direção da presa. Direção anterior do Caçador " + _board.Hunter.FacingDirection + " Direção que precisa andar para ir em direção a presa " + directionToNextCell);
                        _board.Hunter.FacingDirection = directionToNextCell;
                    }
                }
            }
        }
    }
}