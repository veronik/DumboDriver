using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    class Spill : Obstacle
    {
        protected char[,] body;
        public new char[,] Body
        {
            get
            {
                return new char[,] 
            { 
                {' ',' ',' ','.','.',' ',' '},
                {' ',' ','.','.','.','.',' '},
                {' ','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.'},
                {' ','.','.','.','.','.',' '},
                {' ',' ','.','.','.',' ',' '},
            };
            }
            set { body = value; }
        }

        public Spill(MatrixCoords topLeft, Lane lane)
            : base(topLeft, new char[,] 
            { 
                {' ',' ',' ','.','.',' ',' '},
                {' ',' ','.','.','.','.',' '},
                {' ','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.'},
                {' ','.','.','.','.','.',' '},
                {' ',' ','.','.','.',' ',' '},
            }, lane)
        {
            this.speed = 1;
        }

        public override void RespondToCollision(DumboCar car)
        {
            car.DecreaseSpeed(100);
            this.isDestroyed = true;
        }
    }
}
