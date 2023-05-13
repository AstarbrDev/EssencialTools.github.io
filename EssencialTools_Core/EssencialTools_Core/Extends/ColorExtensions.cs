/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine;
using System;

namespace AstarLibrary.Core
{
	[Serializable]
    public static class ColorExtensions 
    {
        #region StaticMethods
        public static Color FromHex(this Color color, string hex)
        {
            Color result;

            if (ColorUtility.TryParseHtmlString(hex, out result))
            {
                return result;
            }
            return color;
        }
        #endregion
    }
}