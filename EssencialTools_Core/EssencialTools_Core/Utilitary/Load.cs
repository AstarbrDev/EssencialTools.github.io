/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Interface of Load
    /// </summary>
    public static class Load 
    {
        #region Variables
        public delegate void LoadHandler(string message);

        internal static event LoadHandler OnLoading;
        internal static event LoadHandler OnLoaded;
        #endregion

        #region Functions
        internal static void Level(int sceneIndex, MonoBehaviour instance, [Optional] UnityEvent sceneEvent)
        {
            instance.StartCoroutine(AsynchronousLoad(sceneIndex, sceneEvent));
        }
        internal static void Level(string sceneName, MonoBehaviour instance, [Optional] UnityEvent sceneEvent)
        {
            instance.StartCoroutine(AsynchronousLoad(sceneName, sceneEvent));
        }
        internal static void Level<T>(T sceneName, MonoBehaviour instance, [Optional] UnityEvent sceneEvent)
        {
            instance.StartCoroutine(AsynchronousLoad(sceneName, sceneEvent));
        }
        internal static void Level<T>(T sceneName, MonoBehaviour instance, [Optional] UnityEvent sceneEvent, [Optional] LoadSceneMode mode)
        {
            instance.StartCoroutine(AsynchronousLoad(sceneName, sceneEvent, mode));
        }
        internal static void LevelWithBar<T>(T sceneName, Slider slider, string text, MonoBehaviour instance, [Optional] UnityEvent sceneEvent)
        {
            instance.StartCoroutine(AsynchronousLoadWithBar(sceneName, slider, text, sceneEvent));
        }
        private static IEnumerator AsynchronousLoad<T>(T scene, [Optional] UnityEvent sceneEvent)
        {
            sceneEvent?.Invoke();

            if (OnLoading != null) OnLoading($"Scene: {scene} start loading");

            var operation = scene is int ? SceneManager.LoadSceneAsync(Convert.ToInt32(scene)) : SceneManager.LoadSceneAsync(Convert.ToString(scene));

            while (!operation.isDone)
            {
                _ = Mathf.Clamp01(operation.progress / .9F);
                yield return null;
            }

            if (OnLoaded != null) OnLoaded($"Scene: {scene} finish loading");
        }
        private static IEnumerator AsynchronousLoad<T>(T scene, [Optional] UnityEvent sceneEvent, [Optional] LoadSceneMode mode)
        {
            sceneEvent?.Invoke();

            if (OnLoading != null) OnLoading($"Scene: {scene} start loading");

            var operation = scene is int ? SceneManager.LoadSceneAsync(Convert.ToInt32(scene), mode) : SceneManager.LoadSceneAsync(Convert.ToString(scene), mode);

            while (!operation.isDone)
            {
                _ = Mathf.Clamp01(operation.progress / .9F);
                yield return null;
            }

            if (OnLoaded != null) OnLoaded($"Scene: {scene} finish loading");
        }
        private static IEnumerator AsynchronousLoadWithBar<T>(T scene, Slider slider, [Optional] string text, [Optional] UnityEvent sceneEvent)
        {
            sceneEvent?.Invoke();

            if (OnLoading != null) OnLoading($"Scene: {scene} start loading");

            var operation = scene is int ? SceneManager.LoadSceneAsync(Convert.ToInt32(scene)) : SceneManager.LoadSceneAsync(Convert.ToString(scene));

            while (!operation.isDone)
            {
                slider.value = Mathf.Clamp01(operation.progress / .9F);
                if (text != null) text = Mathf.Round(slider.value * 100) + "%";
                yield return null;
            }

            if (OnLoaded != null) OnLoaded($"Scene: {scene} finish loading");
        }
        private static IEnumerator AsynchronousUnload<T>(T scene, [Optional] UnityEvent sceneEvent)
        {
            sceneEvent?.Invoke();

            if (OnLoading != null) OnLoading($"Scene: {scene} start loading");

            var operation = scene is int ? SceneManager.UnloadSceneAsync(Convert.ToInt32(scene)) : SceneManager.UnloadSceneAsync(Convert.ToString(scene));

            while (!operation.isDone)
            {
                _ = Mathf.Clamp01(operation.progress / .9F);
                yield return null;
            }

            if (OnLoaded != null) OnLoaded($"Scene: {scene} finish loading");
        }
        internal static IEnumerator AsyncLoadBar(Slider obj, [Optional] TextMeshProUGUI text, float value, float velocity)
        {
            if (OnLoading != null) OnLoading($"Slider: {obj.value} start loading");

            while (obj.value < value)
            {
                obj.value += Time.deltaTime / velocity;
                if (text.text != null) text.text = Mathf.Round(obj.value * 100) + "%";
                yield return new WaitForSeconds(Time.deltaTime / velocity);
            }

            if (OnLoaded != null) OnLoaded($"Slider: {obj.value} start loading");

            yield return null;
        }
        internal static T Resource<T>(string path) where T : Component => _ = Resources.Load<T>(path);
        #endregion
    }
}