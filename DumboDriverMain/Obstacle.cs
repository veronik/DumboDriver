using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class Obstacle : GameObject
    { 
        public Obstacle(MatrixCoords topLeft, char[,] body, Lane lane)
            : base(topLeft, body, lane)
        {
        }
    }
}
