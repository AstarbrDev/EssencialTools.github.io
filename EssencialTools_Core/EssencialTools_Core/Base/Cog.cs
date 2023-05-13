/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Unique Systems
    /// </summary>
    /// <typeparam name="T">Unique System</typeparam>
    public class Cog<T> : MonoBehaviour, IRecordHandler where T : Component
    {
        #region Variables
        public bool Lock = false;
        public bool ShowLog = false;
        public bool persistent = true;

        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null) Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");

                return _instance;
            }
        }
        #endregion

        #region UnityMethods
        protected private virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if (!persistent) return;
                if (transform.parent == null)
                    DontDestroyOnLoad(this);
                else
                    DontDestroyOnLoad(gameObject.transform.root);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        protected private virtual void Start() { }
        protected private virtual void OnEnable() { }
        protected private virtual void OnDisable() { }
        protected private virtual void OnDestroy()
        {
            if (_instance == this)
                _instance = null;
        }
        protected private virtual void OnApplicationPause(bool pause) { }
        protected private virtual void OnApplicationQuit() { }
        #endregion

        #region Methods
        protected virtual void Initialize() { }
        protected virtual void Setup() { }
        public void Log(object message)
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