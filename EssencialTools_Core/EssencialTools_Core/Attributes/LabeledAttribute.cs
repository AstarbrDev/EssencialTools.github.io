/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{

    [AttributeUsage(validOn: AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class LabeledAttribute : PropertyAttribute
    {
        private string _name;
        public string Name { get { return _name; } }

        public LabeledAttribute(string name)
        {
            this._name = name;
        }

    }
}