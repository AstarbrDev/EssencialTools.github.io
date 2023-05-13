/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;

namespace AstarLibrary.Core
{
    [Serializable]
    public static class IntExtensions
    {
        #region StaticMethods

        /// <summary>
        /// Greate Factoryal Common
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GFC(this int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        /// <summary>
        /// Minimum Multiple Common
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int MMC(this int a, int b)
        {
            return (a / GFC(a, b)) * b;
        }
        #endregion
    }
}