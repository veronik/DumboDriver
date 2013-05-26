using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class RandomObjectGenerator
    {
        static Random randomGenerator = new Random();

        public List<GameObject> GenerateObjects(DumboCar car) // Generates one or many objects
        {
            List<GameObject> objList = new List<GameObject>();            
            List<Lane> occupiedLanes = new List<Lane>();

            int chanceObj = randomGenerator.Next(1, 4); //randomize number of obj produced
            for (int i = 0; i < chanceObj; i++)
            {
                // initial value, no effect
                Lane lane = Lane.Left;

                bool isLaneFound = false;
                Array values = Enum.GetValues(typeof(Lane));
                Random random = new Random();

                while (!isLaneFound)
                {
                    lane = (Lane)values.GetValue(random.Next(values.Length)); //randomize lane
                    if (!occupiedLanes.Contains(lane))
                    {
                        isLaneFound = true;
                    }
                }

                MatrixCoords topLeft;
                if (lane == Lane.Left)
                {
                    occupiedLanes.Add(Lane.Left);
                    topLeft = new MatrixCoords(0, 14);
                }
                else if (lane == Lane.MiddleLeft)
                {
                    occupiedLanes.Add(Lane.MiddleLeft);
                    topLeft = new MatrixCoords(0, 25);
                }
                else if (lane == Lane.MiddleRight)
                {
                    occupiedLanes.Add(Lane.MiddleRight);
                    topLeft = new MatrixCoords(0, 36);
                }
                else
                {
                    occupiedLanes.Add(Lane.Right);
                    topLeft = new MatrixCoords(0, 47);
                }

                GameObject obj;
                int chance = randomGenerator.Next(0, 100); //randomize TimeBonus or else
                if (Timer.TimeLeft<25 && chance < 20 - car.Points/100)
                {
                    obj = new TimeBonus(topLeft, lane);
                }
                else
                {
                    chance = randomGenerator.Next(0, 100); //randomize object types
                    if (chance < 25)
                    {
                        obj = new Reward(topLeft, lane, randomGenerator.Next(1, 10)); //randomize reward values
                    }
                    else if (chance < 50)
                    {
                        obj = new Cone(topLeft, lane);
                    }
                    else if (chance < 75)
                    {
                        obj = new OtherCar(topLeft, lane);
                    }
                    else
                    {
                        obj = new Spill(topLeft, lane);
                    }
                }                    
                objList.Add(obj);
            }
                   
            return objList;
        }
    }
}

