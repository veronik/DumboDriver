using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    class PointsInfo : GameInfo
    {

        public PointsInfo(int points)
        {
            StringBuilder pointsOutput = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                if (points.ToString().Length > i)
                {
                    pointsOutput.Append(points.ToString()[i]);
                }
                else
                {
                    pointsOutput.Append(' ');
                }
            }

            this.body = new char[,] { {'P','O','I','N','T','S',':',
                                       pointsOutput.ToString()[0],pointsOutput.ToString()[1],pointsOutput.ToString()[2],pointsOutput.ToString()[3],pointsOutput.ToString()[4], } };
            this.topLeft = new MatrixCoords(26,47);
        }
    }
}
