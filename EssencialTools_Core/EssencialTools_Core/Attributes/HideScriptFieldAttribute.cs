/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Hides script monobehaviour
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class HideScriptFieldAttribute : Attribute { }
}