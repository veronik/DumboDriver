using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    class OtherCar : Obstacle
    {
        protected char[,] body;
        public new char[,] Body
        {
            get
            {
                return new char[,] 
                { 
                    {' ',' ','_','_','_',' ',' '},
                    {' ','/','_','_','_','\\',' '},
                    {'.','"',' ','|',' ','"','.'},
                    {'(','o','_','|','_','o',')'},
                    {' ','u',' ',' ',' ','u',' '},
                };
            }
            set { body = value; }
        }

        public OtherCar(MatrixCoords topLeft, Lane lane)
            : base(topLeft, new char[,] 
            { 
                {' ',' ','_','_','_',' ',' '},
                {' ','/','_','_','_','\\',' '},
                {'.','"',' ','|',' ','"','.'},
                {'(','o','_','|','_','o',')'},
                {' ','u',' ',' ',' ','u',' '},
            }, lane)
        {
            this.speed = 1;
        }

        public override void RespondToCollision(DumboCar car)
        {
            car.DecreaseSpeed(140);
            this.isDestroyed = true;
        }
    }
}
