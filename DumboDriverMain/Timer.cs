using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public static class Timer
    {
        public static int timeToReachCheckpoint = 30;

        private static DateTime startTime;

        public static DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private static DateTime endTime; 

        public static DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private static int timeLeft = timeToReachCheckpoint;
        public static int TimeLeft
        {
            get { return timeLeft; }
            set { timeLeft = value; }
        }

        private static int intervalCount;
        public static int IntervalCount
        {
            get { return Timer.intervalCount; }
            set { Timer.intervalCount = value; }
        }
        
        public static void Tick()
        {
            timeLeft = timeToReachCheckpoint - (EndTime - StartTime).Minutes*60 - (EndTime - StartTime).Seconds;            
            intervalCount++;
        }
    }
}
