/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{
    [Serializable]
    public static class PlayerPref
    {
        #region Functions
        public static void Set<T>(string key, T value)
        {
            if (typeof(T) == typeof(int))
            {
                PlayerPrefs.SetInt(key, (int)(object)value);
            }
            else if (typeof(T) == typeof(float))
            {
                PlayerPrefs.SetFloat(key, (float)(object)value);
            }
            else if (typeof(T) == typeof(string))
            {
                PlayerPrefs.SetString(key, (string)(object)value);
            }
            else if (typeof(T) == typeof(bool))
            {
                PlayerPrefs.SetInt(key, (bool)(object)value ? 1 : 0);
            }
            else if (typeof(T).IsEnum)
            {
                PlayerPrefs.SetInt(key, (int)(object)value);
            }
            else if (typeof(T).IsArray)
            {
                var jsonArray = JsonUtility.ToJson(value);
                PlayerPrefs.SetString(key, jsonArray);
            }
            else
            {
                Debug.LogErrorFormat("Unsupported type: {0}", typeof(T).FullName);
            }
        }
        public static T Get<T>(string key, T defaultValue = default)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
            }
            else if (typeof(T) == typeof(float))
            {
                return (T)(object)PlayerPrefs.GetFloat(key, (float)(object)defaultValue);
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
            }
            else if (typeof(T) == typeof(bool))
            {
                return (T)(object)(PlayerPrefs.GetInt(key, (bool)(object)defaultValue ? 1 : 0) != 0);
            }
            else if (typeof(T).IsEnum)
            {
                return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
            }
            else if (typeof(T).IsArray)
            {
                var jsonArray = PlayerPrefs.GetString(key);
                if (string.IsNullOrEmpty(jsonArray))
                {
                    return defaultValue;
                }
                return JsonUtility.FromJson<T>(jsonArray);
            }
            else
            {
                Debug.LogErrorFormat("Unsupported type: {0}", typeof(T).FullName);
                return defaultValue;
            }
        }
        #endregion
    }
}