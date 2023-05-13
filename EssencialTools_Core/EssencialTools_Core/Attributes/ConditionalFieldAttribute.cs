
/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AstarLibrary.Core
{
    /// <summary>
    /// Attribute to help edition
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ConditionalFieldAttribute : PropertyAttribute
    {
        #region Variables
        private readonly string _propertyToCheck;
        private readonly object _compareValue;
        #endregion

        #region Constructor
        public ConditionalFieldAttribute(string propertyToCheck, object compareValue = null)
        {
            _propertyToCheck = propertyToCheck;
            _compareValue = compareValue;
        }
        #endregion

        #region PublicMethods
        public bool CheckBehaviourPropertyVisible(MonoBehaviour behaviour, string propertyName)
        {
            if (string.IsNullOrEmpty(_propertyToCheck)) return true;

            SerializedObject so = new SerializedObject(behaviour);
            var property = so.FindProperty(propertyName);

            return CheckPropertyVisible(property);
        }
        public bool CheckPropertyVisible(SerializedProperty property)
        {
            var conditionProperty = FindRelativeProperty(property, _propertyToCheck);
            if (conditionProperty == null) return true;

            var isBoolMatch = conditionProperty.propertyType == SerializedPropertyType.Boolean && conditionProperty.boolValue;
            var compareStringValue = _compareValue != null ? _compareValue.ToString().ToUpper() : "NULL";
            if (isBoolMatch && compareStringValue == "FALSE") isBoolMatch = false;

            var conditionPropertyStringValue = AsStringValue(conditionProperty).ToUpper();
            var objectMatch = compareStringValue == conditionPropertyStringValue;

            var notVisible = !isBoolMatch && !objectMatch;
            return !notVisible;
        }
        #endregion

        #region PrivateMethods
        private SerializedProperty FindRelativeProperty(SerializedProperty property, string toGet)
        {
            if (property.depth == 0) return property.serializedObject.FindProperty(toGet);

            var path = property.propertyPath.Replace(".Array.data[", "[");
            var elements = path.Split('.');

            var nestedProperty = NestedPropertyOrigin(property, elements);

            // if nested property is null = we hit an array property
            if (nestedProperty == null)
            {
                var cleanPath = path.Substring(0, path.IndexOf('['));
                var arrayProp = property.serializedObject.FindProperty(cleanPath);
                if (_warningsPool.Contains(arrayProp.exposedReferenceValue)) return null;
                var target = arrayProp.serializedObject.targetObject;
                var who = string.Format("Property <color=brown>{0}</color> in object <color=brown>{1}</color> caused: ", arrayProp.name, target.name);

                Debug.LogWarning(who + "Array fields is not supported by [ConditionalFieldAttribute]", target);
                _warningsPool.Add(arrayProp.exposedReferenceValue);
                return null;
            }

            return nestedProperty.FindPropertyRelative(toGet);
        }
        private SerializedProperty NestedPropertyOrigin(SerializedProperty property, string[] elements)
        {
            SerializedProperty parent = null;

            for (var i = 0; i < elements.Length - 1; i++)
            {
                var element = elements[i];
                var index = -1;
                if (element.Contains("["))
                {
                    index = Convert.ToInt32(element.Substring(element.IndexOf("[", StringComparison.Ordinal)).Replace("[", "").Replace("]", ""));
                    element = element.Substring(0, element.IndexOf("[", StringComparison.Ordinal));
                }

                parent = i == 0 ? property.serializedObject.FindProperty(element) : parent.FindPropertyRelative(element);

                if (index >= 0) parent = parent.GetArrayElementAtIndex(index);
            }

            return parent;
        }
        private string AsStringValue(SerializedProperty prop)
        {
            switch (prop.propertyType)
            {
                case SerializedPropertyType.String:
                    return prop.stringValue;

                case SerializedPropertyType.Character:
                case SerializedPropertyType.Integer:
                    if (prop.type == "char") return Convert.ToChar(prop.intValue).ToString();
                    return prop.intValue.ToString();

                case SerializedPropertyType.ObjectReference:
                    return prop.objectReferenceValue != null ? prop.objectReferenceValue.ToString() : "null";

                case SerializedPropertyType.Boolean:
                    return prop.boolValue.ToString();

                case SerializedPropertyType.Enum:
                    return prop.enumNames[prop.enumValueIndex];

                default:
                    return string.Empty;
            }
        }

        private readonly HashSet<object> _warningsPool = new HashSet<object>();
        #endregion
    }
}

