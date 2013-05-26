using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class Cone : Obstacle
    {
        protected char[,] body;
        public new char[,] Body
        {
            get
            {
                return new char[,] 
            { 
                {' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ','/','\\',' ',' ',' '},
                {'|','-','/','-','-','\\','-','|'},
                {'|','-','-','-','-','-','-','|'},
            };
            }
        }

        public Cone(MatrixCoords topLeft, Lane lane)
            : base(topLeft, new char[,] 
            { 
                {' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ','/','\\',' ',' ',' '},
                {'|','-','/','-','-','\\','-','|'},
                {'|','-','-','-','-','-','-','|'},
            }, lane)
        {
            this.speed = 1;
        }

        public override void RespondToCollision(DumboCar car)
        {
            car.DecreaseSpeed(80);
            this.isDestroyed = true;
        }
    }
}
