/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Component Type Controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Controller<T> : Module where T : Component
    {
        #region Variables
        public List<T> GroupController;
        #endregion

        #region PublicMethods
        public virtual void Subscribe(T obj) => GroupController.Add(obj);
        #endregion

        #region IEnumerator
        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }
        #endregion

        #region InternalMethods
        internal virtual void Init() { }
        internal virtual void Setup() { }
        internal virtual void Logic() { }
        #endregion
    }
}