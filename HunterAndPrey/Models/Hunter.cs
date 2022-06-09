using System;
using HunterAndPrey.Enums;

namespace HunterAndPrey.Models
{
    public class Hunter : Cell
    {
        private Direction _direction;
        public Direction FacingDirection
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;

                Color = DirectionHelper.Color(FacingDirection);
            }
        }

        public Hunter()
        {
            Content = "[H]";
        }

        
    }
}