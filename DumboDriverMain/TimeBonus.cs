using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    class TimeBonus : GameObject
    {
        protected char[,] body;
        public new char[,] Body
        {
            get
            {
                return new char[,] 
            {
                {' ',' ','_','_',' ',' '},
                {' ','/',' ',' ','\\',' '},
                {'|','t','i','m','e','|'},
                {' ','\\','_','_','/',' '},
            };
            }
            set
            { body = value; }
        }

        public TimeBonus(MatrixCoords topLeft, Lane lane)
            : base(topLeft, new char[,] 
            { 
                {' ',' ','_','_',' ',' '},
                {' ','/',' ',' ','\\',' '},
                {'|','t','i','m','e','|'},
                {' ','\\','_','_','/',' '},
            }, lane)
        {
            this.speed = 1;
        }

        public override void RespondToCollision(DumboCar car)
        {
            Timer.timeToReachCheckpoint += 10;
            this.isDestroyed = true;
        }
    }
}
