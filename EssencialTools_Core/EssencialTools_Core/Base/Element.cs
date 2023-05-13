/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine;


namespace AstarLibrary.Core
{
    /// <summary>
    /// Simple Component
    /// </summary>
    /// 
    [AddComponentMenu("UI/Bases/Element")]
    public class Element : MonoBehaviour
    {
        #region Variables
        public bool Lock = false;
        public bool ShowLog = false;
        #endregion

        #region PublicMethods
        public virtual void Log(object message)
        {
#if UNITY_EDITOR
            if (ShowLog)
            {
                if (message is Memo)
                {
                    Report.Log((Memo)message);
                }
                else if (message is string)
                {
                    Debug.Log(message);
                }
                else
                {
                    Debug.LogWarning($"Unknown message type: {message.GetType()}");
                }
            }
#endif
        }
        #endregion
    }
}
