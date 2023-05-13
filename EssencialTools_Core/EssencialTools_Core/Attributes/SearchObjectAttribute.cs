/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{
    public sealed class SearchObjectAttribute : PropertyAttribute
    {
        #region Functions

        public Type searchObjectType;

        #endregion

        #region Constructor
        public SearchObjectAttribute(Type searchObjectType)
        {
            this.searchObjectType = searchObjectType;
        }
        #endregion
    }
}