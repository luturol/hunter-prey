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
                    Console.WriteLine("Caçador andou uma posição na diração " + _board.Hunter.FacingDirection);

                    #region Direction Validation
                    if (_board.Hunter.FacingDirection == Direction.South)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y + 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.Southeast)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y + 1 && cell.X == _board.Hunter.X + 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.SouthWest)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y + 1 && cell.X == _board.Hunter.X - 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.East)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y && cell.X == _board.Hunter.X + 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.West)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y && cell.X == _board.Hunter.X - 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.North)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y - 1 && cell.X == _board.Hunter.X);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.NorthEast)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y - 1 && cell.X == _board.Hunter.X + 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    else if (_board.Hunter.FacingDirection == Direction.Northwest)
                    {                        
                        var nextPosition = neighbours.FirstOrDefault(cell => cell.Y == _board.Hunter.Y - 1 && cell.X == _board.Hunter.X - 1);
                        if (nextPosition is not null)
                        {
                            Console.WriteLine($"Caçador andou da posição x,y {_board.Hunter.X},{_board.Hunter.Y} para {nextPosition.X},{nextPosition.Y}");
                            _board.MovePosition(_board.Hunter, nextPosition.X, nextPosition.Y);
                            hasSetNewPosition = true;
                        }
                    }
                    #endregion Direction Validation
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