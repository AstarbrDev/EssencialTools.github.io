/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Label array Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class LabeledArrayAttribute : PropertyAttribute
    {
        public readonly string[] names;
        public LabeledArrayAttribute(string[] names) { this.names = names; }
        public LabeledArrayAttribute(Type enumType) { names = Enum.GetNames(enumType); }
    }
}