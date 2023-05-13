/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System.Collections;
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Base Component
    /// </summary>
    [System.Serializable]
    [AddComponentMenu("UI/Bases/Module")]
    public class Module : MonoBehaviour, IRecordHandler
    {
        #region Variables
        public bool Lock = false;

        public bool ShowLog = false;

        public StartType PlayMode = StartType.Awake;

        public float PlayModeDelay = 0;

        public Coroutine Routine = null;
        #endregion

        #region UnityMethods
        public virtual void Awake()
        {
            switch (PlayMode)
            {
                case StartType.Dont:                                                                 break;
                case StartType.Enabled: PlayModeDelay = 0;                                           break;
                case StartType.Awake:   PlayModeDelay = 0; Routine = StartCoroutine(Initialize());   break;
                case StartType.Delayed:                    Routine = StartCoroutine(Initialize());   break;
            }
        }
        public virtual void OnEnable()
        {
            if (PlayMode == StartType.Enabled) StartCoroutine(Initialize());
        }
        public virtual void OnDisable() { }
        public virtual void OnApplicationQuit()
        {
            if (Routine != null) StopCoroutine(Routine);
        }
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

        #region PublicIEnumerators
        public virtual IEnumerator Initialize()
        {
            yield return new WaitForSeconds(PlayModeDelay);
        }
        #endregion
    }
}