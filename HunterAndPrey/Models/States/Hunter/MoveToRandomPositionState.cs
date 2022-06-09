using System;
using System.Linq;
using HunterAndPrey.Enums;

namespace HunterAndPrey.Models.States.Hunter
{
    public class MoveToRandomPositionState : State
    {
        public MoveToRandomPositionState(Board board) : base(board)
        {
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Enter()
        {
            
            var neighbours = _board.GetNeighbours(_board.Hunter.X, _board.Hunter.Y);

            bool hasSetNewPosition = false;
            while (!hasSetNewPosition)
            {
                var randomDirection = DirectionHelper.Random();
                if (randomDirection == _board.Hunter.FacingDirection)
                {
                    //Move to facing direction
                    if (_board.Hunter.FacingDirection == Direction.South)
                    {
                        Console.WriteLine("Caçador andou uma posição na diração " + _board.Hunter.FacingDirection);
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y + 1);
                        if (nextPosition is not null)
                        {
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Caçador mudou de direção. Foi da " + _board.Hunter.FacingDirection + " para " + randomDirection);
                    _board.Hunter.FacingDirection = randomDirection;
                    hasSetNewPosition = true;
                    // var randomPos = neighbours[new Random().Next(0, neighbours.Count() - 1)];

                    // Console.WriteLine($"Posicação atual do Hunter: x = {_board.Hunter.X} y = {_board.Hunter.Y} posição para qual vai se mover x = {randomPos.X} y = {randomPos.Y}");
                    // _board.MovePosition(_board.Hunter, randomPos.X, randomPos.Y);
                }
            }
        }
    }
}