/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System.Collections;
using UnityEngine;

namespace AstarLibrary.Core
{
    public static class CoroutineExtensions
    {
        #region Variables
        public static IEnumerator Function;
        #endregion

        #region PublicMethods
        public static Coroutine Begin(this MonoBehaviour mono, IEnumerator function)
        {
            Function = function;

            return mono.StartCoroutine(Function);
        }
        public static void Pause(this MonoBehaviour mono)
        {
            if (Function == null)
            {
                throw new System.ArgumentNullException("Function Empty");
            }
            mono.StopCoroutine(Function);
        }
        public static void Resume(this MonoBehaviour mono)
        {
            if (Function == null)
            {
                throw new System.ArgumentNullException("Function Empty");
            }
            mono.StartCoroutine(Function);
        }
        #endregion
    }
}