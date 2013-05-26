using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class SpeedInfo : GameInfo
    {
        public SpeedInfo(int speed)
        {
            StringBuilder speedOutput = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                if (speed.ToString().Length > i)
                {
                    speedOutput.Append(speed.ToString()[i]);
                }
                else
                {
                    speedOutput.Append(' ');
                }
            }

            this.body = new char[,] { {'S','P','E','E','D',':',
                                       speedOutput.ToString()[0],speedOutput.ToString()[1],speedOutput.ToString()[2], } };
            this.topLeft = new MatrixCoords(26,7);
        }
    }
}
