/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{
    public static class RectTransformExtensions
    {
        #region Functions
        public static AnchorType GetAnchorType(this RectTransform rect)
        {
            if (rect.anchorMax == Vector2.one && rect.anchorMin == Vector2.zero)
            {
                return AnchorType.Fullscale;
            }
            else if (rect.anchorMin.x == 0 && rect.anchorMax.x == 1)
            {
                return AnchorType.StrechHorizontal;
            }
            else if (rect.anchorMin.y == 0 && rect.anchorMax.y == 1)
            {
                return AnchorType.StrechVertical;
            }
            else
            {
                return AnchorType.Normal;
            }
        }
        public static void AnchorToCorners(this RectTransform transform)
        {
            if (transform == null)
                throw new ArgumentNullException("transform");

            if (transform.parent == null)
                return;

            var parent = transform.parent.GetComponent<RectTransform>();

            Vector2 newAnchorsMin = new Vector2(transform.anchorMin.x + transform.offsetMin.x / parent.rect.width,
                              transform.anchorMin.y + transform.offsetMin.y / parent.rect.height);

            Vector2 newAnchorsMax = new Vector2(transform.anchorMax.x + transform.offsetMax.x / parent.rect.width,
                              transform.anchorMax.y + transform.offsetMax.y / parent.rect.height);

            transform.anchorMin = newAnchorsMin;
            transform.anchorMax = newAnchorsMax;
            transform.offsetMin = transform.offsetMax = new Vector2(0, 0);
        }
        public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
        {
            trans.pivot = aVec;
            trans.anchorMin = aVec;
            trans.anchorMax = aVec;
        }
        public static Vector2 GetSize(this RectTransform trans)
        {
            return trans.rect.size;
        }
        public static float GetWidth(this RectTransform trans)
        {
            return trans.rect.width;
        }
        public static float GetHeight(this RectTransform trans)
        {
            return trans.rect.height;
        }
        public static float GetLeft(this RectTransform trans)
        {
            return trans.rect.xMin;
        }
        public static float GetRight(this RectTransform trans)
        {
            return trans.rect.xMax;
        }
        public static float GetTop(this RectTransform trans)
        {
            return trans.rect.yMin;
        }
        public static float GetBottom(this RectTransform trans)
        {
            return trans.rect.yMax;
        }
        public static void SetSize(this RectTransform trans, Vector2 newSize)
        {
            Vector2 oldSize = trans.rect.size;
            Vector2 deltaSize = newSize - oldSize;
            trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
            trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
        }
        public static void SetWidth(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(newSize, trans.rect.size.y));
        }
        public static void SetHeight(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(trans.rect.size.x, newSize));
        }
        public static void SetBottomLeftPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }
        public static void SetTopLeftPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }
        public static void SetBottomRightPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }
        public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }
        public static RectTransform GetTopRectTransformOfCanvas(this RectTransform trans)
        {
            Canvas[] c = trans.GetComponentsInParent<Canvas>();
            Canvas topMostCanvas = c[c.Length - 1];

            return topMostCanvas.GetComponent<RectTransform>();
        }
        public static RectTransform ChangeRectStretched(this RectTransform obj, RectSide side, float number)
        {
            switch (side)
            {
                case RectSide.Left:
                    obj.offsetMin = new Vector2(-number, obj.offsetMin.y);
                    return obj;

                case RectSide.Right:
                    obj.offsetMax = new Vector2(number, obj.offsetMax.y);
                    return obj;

                case RectSide.Bottom:
                    obj.offsetMin = new Vector2(obj.offsetMin.x, number);
                    return obj;

                case RectSide.Top:
                    obj.offsetMax = new Vector2(obj.offsetMax.x, -number);
                    return obj;

                default: throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }
        public static T FindComponentInParents<T>(this Transform transform) where T : Component
        {
            if (transform == null) return null;

            T component = transform.GetComponent<T>();
            if (component != null) return component;

            if (transform.parent != null)
            {
                return transform.parent.FindComponentInParents<T>();
            }

            return null;
        }
        #endregion

        #region Data
        public enum AnchorType
        {
            Normal = 0,
            Fullscale = 1,
            StrechHorizontal = 2,
            StrechVertical = 3,
        }
        public enum RectSide
        {
            Left = 0,
            Right = 1,
            Top = 2,
            Bottom = 3,
        }
        #endregion
    }
}