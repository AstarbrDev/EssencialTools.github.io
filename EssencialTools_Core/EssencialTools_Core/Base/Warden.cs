/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine.Events;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Oveerseer of Workers
    /// </summary>
    public class Warden : Module, IOverseerHandler
    {
        #region Variables
        public bool IsDone = false;

        public string Message = string.Empty;

        public UnityEvent<string> Callback;

        public UnityEvent OnComplete;
        #endregion

        #region Internal
        protected internal virtual void Setup() { }
        #endregion

        #region PublicMethods
        public virtual void Subscription() { }
        public virtual void Watch(object obj) { }
        public virtual void Notify(object obj) { }
        #endregion
    }
}
