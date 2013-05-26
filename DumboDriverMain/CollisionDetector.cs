using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class CollisionDetector
    {
        public static void HandleCollisions(DumboCar car, List<GameObject> movingObjects)
        {
            foreach (var obj in movingObjects)
            {
                if (car.Lane == obj.Lane)
                {
                    for (int i = 0; i < obj.Body.GetLength(0); i++)
                    {
                        for (int j = 0; j < car.Body.GetLength(0); j++)
                        {
                            if (car.TopLeft.Row + j == obj.TopLeft.Row + i || car.TopLeft.Row + j == obj.TopLeft.Row + i)
                            {
                                obj.RespondToCollision(car);
                                return;
                            }
                        }                       
                    }    
                }
            }
        }

        public static void HandleScreenExit(List<GameObject> movingObjects, Field currentField)
        {
            foreach (var obj in movingObjects)
            {
                if (obj.TopLeft.Row + obj.Body.GetLength(0) == currentField.Body.GetLength(0) - 2)
                {
                    obj.ExitScreen();
                }
            }
        }

    }
}
