/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System.Linq;
using UnityEngine;


namespace AstarLibrary.Core
{
    public static class GameObjectExtensions
    {
        #region Functions
        /// <summary>
        /// Find Object by Instance ID
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="instanceID"></param>
        /// <returns></returns>
        public static GameObject FindObjectByInstanceID(this GameObject obj, int instanceID)
        {
            GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            foreach (GameObject obje in objects)
            {
                if (obje.GetInstanceID() == instanceID)
                {
                    return obje;
                }
            }
            return null;
        }
        /// <summary>
        /// Find object not attach to script in hierarchy.
        /// </summary>
        /// <returns>The in hierarchy.</returns>
        /// <param name="name">Name of object to be found on hierarchy.</param>
        public static GameObject FindInHierarchyInative(this GameObject obj, string name)
        {
            var objInactiveAll = Resources.FindObjectsOfTypeAll<GameObject>();

            foreach (var item in objInactiveAll)
                if (item.name == name)
                    obj = item;

            return obj;
        }
        /// <summary>
        /// Get the child base on name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetChild<T>(this GameObject obj, string name) where T : Component
        {
            var childs = obj.transform.GetComponentsInChildren<T>(true);

            foreach (var child in childs)
                if (child.gameObject.name == name)
                    return child;

            return null;
        }
        /// <summary>
        /// Get the child base on name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetChild<T>(this GameObject obj) where T : Component
        {
            var childs = obj.transform.GetComponentsInChildren<T>(true);

            return childs.FirstOrDefault();
        }
        /// <summary>
        /// Gets the father based on GameObject.
        /// </summary>
        /// <returns>The father.</returns>
        /// <param name="obj"> GameObject that contains father.</param>
        /// <param name="name"> Name of the father to be found.</param>
        public static GameObject GetFather(this GameObject obj, string name)
        {
            var father = obj.transform.root;

            if (father.name == name)
            {
                return father.gameObject;
            }
            else
            {
                var uncles = father.GetComponentsInChildren<Transform>(true);

                foreach (var child in uncles)
                    if (child.name == name)
                        return child.gameObject;
            }

            return null;
        }
        /// <summary>
        /// Gets the father by GameObject Only.
        /// </summary>
        /// <returns>The father.</returns>
        /// <param name="obj"> Get's the first GameObject father of hierarchy</param>
        public static GameObject GetFather(this GameObject obj)
        {
            var father = obj.transform.root;

            return father.gameObject;
        }
        /// <summary>
        /// Copy Component's
        /// </summary>
        /// <returns>Copy selected component's.</returns>
        /// <param name="componente">Component.</param>
        /// <param name="destiny">Game object to Paste.</param>
        /// <typeparam name="T">Object.GetComponent(Typeof).</typeparam>
        public static T CopyComponent<T>(this GameObject obj, T componente) where T : Component
        {
            var type = componente.GetType();

            var copy = obj.AddComponent(type);

            var fields = type.GetFields();

            foreach (var field in fields) field.SetValue(copy, field.GetValue(componente));

            return copy as T;
        }
        /// <summary>
        /// Copy Component's
        /// </summary>
        /// <returns>Copy selected component's.</returns>
        /// <param name="componente">Component.</param>
        /// <param name="destiny">Game object to Paste.</param>
        /// <typeparam name="T">Object.GetComponent(Typeof).</typeparam>
        public static T CopyComponent<T>(this GameObject obj, GameObject destiny, T componente) where T : Component
        {
            var type = componente.GetType();

            var copy = destiny.AddComponent(type);

            var fields = type.GetFields();

            foreach (var field in fields) field.SetValue(copy, field.GetValue(componente));

            return copy as T;
        }
        #endregion
    }
}
