/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine;
using UnityEngine.Events;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Component Complex
    /// </summary>

    [AddComponentMenu("UI/Bases/Hull")]
    public class Hull : Module
    {
        #region Variables
        public bool ShowEvents = false;

        public UnityEvent OnFinish = null;
        #endregion
    }
}
