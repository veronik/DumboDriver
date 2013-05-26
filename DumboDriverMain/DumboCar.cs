using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class DumboCar : GameObject
    {
        private const int LaneWidth = 11;

        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }     

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
        }

        public static DumboCar getInstance(MatrixCoords topLeft, Lane lane, int speed)
	    {
		    if (instance == null)
			    instance = new DumboCar(topLeft,lane,speed);

		    return instance;
	    }

        private static DumboCar instance;
        private DumboCar (MatrixCoords topLeft, Lane lane, int speed)
            : base(topLeft, new char[,] 
            { 
                {' ',' ','_','_','_',' ',' '},
                {' ','/','_','_','_','\\',' '},
                {'.','"',' ','|',' ','"','.'},
                {'(','o','_','|','_','o',')'},
                {' ','u',' ',' ',' ','u',' '},
            }, lane)
        {
            this.speed = speed;
            this.points = 0;
        }

        public override void Update()
        {
            if (this.speed<200)
            {
                this.IncreaseSpeed(20);
            }
            else if (this.speed<300)
            {
                this.IncreaseSpeed(10);
            }
        }

        public void IncreaseSpeed(int value)
        {
            this.speed += value;
        }

        public void DecreaseSpeed(int decreaseValue)
        {
            try
            {
                if (decreaseValue > this.speed)
                {
                    throw new InvalidSpeedOperationException();
                }
            }
            catch (InvalidSpeedOperationException)
            {
                decreaseValue = this.speed;
            }
            finally
            {
                this.speed -= decreaseValue;
            }            
        }

        public void MoveLeft()
        {
            if (this.Lane!=Lane.Left)
            {
                this.topLeft.Col -= LaneWidth;
                int laneNum = (int)this.Lane;
                laneNum--;
                this.Lane = (Lane)laneNum;
            }            
        }

        public void MoveRight()
        {
            if (this.Lane!=Lane.Right)
            {
                this.topLeft.Col += LaneWidth;
                int laneNum = (int)this.Lane;
                laneNum++;
                this.Lane = (Lane)laneNum;
            }            
        }
    }
}
