/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/

using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Manager Component Type
    /// </summary>
    /// 
    [AddComponentMenu("UI/Bases/Manager")]
    public class Manager : Hull { }

    /// <summary>
    /// Unique Manager Component Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Manager<T> : Cog<T> where T : Component { }

}
