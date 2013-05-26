using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    class TimeLeftInfo : GameInfo
    {
        public TimeLeftInfo(int timeLeft)
        {
            StringBuilder timeOutput = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                if (timeLeft.ToString().Length > i)
                {
                    timeOutput.Append(timeLeft.ToString()[i]);
                }
                else
                {
                    timeOutput.Append(' ');
                }
            }

            this.body = new char[,] { {'T','I','M','E',':',
                                       timeOutput.ToString()[0],timeOutput.ToString()[1], } };
            this.topLeft = new MatrixCoords(26,25);
        }
    }
}
