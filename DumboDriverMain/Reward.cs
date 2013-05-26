using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class Reward : GameObject
    {
        private int value;
        public int Value
        {
            get { return value; }
            set { value = 1; }
        } 

        protected char[,] body;
        public new char[,] Body
        {
            get
            {
                return new char[,] 
            {
                {' ',' ','_','_',' ',' '},
                {' ','/',' ',' ','\\',' '},
                {'|',' ',' ','0',' ','|'},
                {' ','\\','_','_','/',' '},
            };
            }
        }

        public Reward(MatrixCoords topLeft, Lane lane, int value)
            : base(topLeft, new char[,] 
            { 
                {' ',' ','_','_',' ',' '},
                {' ','/',' ',' ','\\',' '},
                {'|',' ',(char)(value+48),'0',' ','|'},
                {' ','\\','_','_','/',' '},
            }, lane)
        {
            this.value = value;
            this.speed = 1;
        }

        public override void RespondToCollision(DumboCar car)
        {
            car.Points += value*10;
            this.isDestroyed = true;
        } 
    }
}
