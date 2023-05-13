/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine.UI;

namespace AstarLibrary.Core
{
    [Serializable]
    public static class InterfaceExtensions
    {
        #region Variables
        static Slider.SliderEvent emptySliderEvent = new Slider.SliderEvent();
        #endregion

        #region Functions
        public static void SetValue(this Slider instance, float value)
        {
            var originalEvent = instance.onValueChanged;
            instance.onValueChanged = emptySliderEvent;
            instance.value = value;
            instance.onValueChanged = originalEvent;
        }

        static Toggle.ToggleEvent emptyToggleEvent = new Toggle.ToggleEvent();
        public static void SetValue(this Toggle instance, bool value)
        {
            var originalEvent = instance.onValueChanged;
            instance.onValueChanged = emptyToggleEvent;
            instance.isOn = value;
            instance.onValueChanged = originalEvent;
        }

        static InputField.OnChangeEvent emptyInputFieldEvent = new InputField.OnChangeEvent();
        public static void SetValue(this InputField instance, string value)
        {
            var originalEvent = instance.onValueChanged;
            instance.onValueChanged = emptyInputFieldEvent;
            instance.text = value;
            instance.onValueChanged = originalEvent;
        }

        static Dropdown.DropdownEvent emptyDropdownFieldEvent = new Dropdown.DropdownEvent();
        public static void SetValue(this Dropdown instance, int value)
        {
            var originalEvent = instance.onValueChanged;
            instance.onValueChanged = emptyDropdownFieldEvent;
            instance.value = value;
            instance.onValueChanged = originalEvent;
        }
        #endregion

    }
}