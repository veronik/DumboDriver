using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class InvalidSpeedOperationException : InvalidOperationException
    {
        public override string Message
        {
            get
            {
                return "Speed cannot be less than 0";
            }
        }
    }
}
