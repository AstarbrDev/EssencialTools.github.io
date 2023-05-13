/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public sealed class SplitAttribute : PropertyAttribute
    {
        #region Functions

        public int spaceBefore = 10;
        public int spaceAfter = 10;
        public float thickness = 1f;
        public Color color = Color.gray;

        #endregion

        #region Constructor
        public SplitAttribute(int spaceBefore = 10, int spaceAfter = 10, float thickness = 1f, float r = 0.5f, float g = 0.5f, float b = 0.5f, float a = 0.2F)
        {
            this.spaceBefore = spaceBefore;
            this.spaceAfter = spaceAfter;
            this.thickness = thickness;
            this.color = new Color(r, g, b, a);
        }
        #endregion
    }
}