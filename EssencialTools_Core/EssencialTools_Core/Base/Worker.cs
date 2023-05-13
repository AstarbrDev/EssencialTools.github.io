/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System.Collections;
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Connector of all Logics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Worker<T> : Module, IWorkerHandler where T : Component
    {
        #region Variables
        public bool Active = false;

        public float Tick = 0;

        public string Description = "Work Description";
        #endregion

        #region Internal
        protected internal virtual void Setup() { }
        #endregion

        #region PublicMethods
        public virtual void Subscription() { }
        public virtual void Execute() { }
        #endregion

        #region ProtectedIEnumerators
        protected virtual IEnumerator Duty()
        {
            yield return null;
        }
        #endregion

    }
}