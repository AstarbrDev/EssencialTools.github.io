/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using System.Diagnostics;

namespace AstarLibrary.Core
{
    public static class Stamp
    {
        #region Variables
        private static float systeminitializesequency = 0.001F;
        public static float SystemInitializeSequency()
        {
            return systeminitializesequency += 0.001F;
        }

        public static Stopwatch Clock;
        #endregion

        #region PublicMethods
        public static string StartTimer()
        {
            Clock = new Stopwatch();
            Clock.Start();
            return Clock.Elapsed.Seconds.ToString();
        }
        public static string MarktTime() => Clock.Elapsed.Seconds.ToString();
        public static string FinishTimer()
        {
            Clock.Stop();
            return Clock.Elapsed.Seconds.ToString();
        }

        public static string MarkTimeNow()
        {
            return DateTime.Now.ToLongTimeString();
        }
        #endregion
    }
}