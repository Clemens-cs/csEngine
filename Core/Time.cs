using System;
using System.Diagnostics;
namespace csEngine.Core
{
    public class Time
    {
        public TimeSpan totalGameTime { get; set; }
        public TimeSpan elapsedGameTime { get; set; }

        private static long second = 1000000000L;

        public static double getTime()
        {
            return (double)nanoTime() / (double)second;
        }

        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        public Time()
        {
            totalGameTime = TimeSpan.Zero;
            elapsedGameTime = TimeSpan.Zero;
        }

        public Time(TimeSpan totalGameTime, TimeSpan elapsedGameTime)
        {
            this.totalGameTime = totalGameTime;
            this.elapsedGameTime = elapsedGameTime;
        }

        
    }
}
