using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{    public static class Inputs
    {
        public static string MOUSE_SCROLL = "Mouse ScrollWheel";
        public static string MOUSE_X_AXIS = "Mouse X";
        public static string MOUSE_Y_AXIS = "Mouse Y";
        public static string KEYBOARD_HORIZONTAL = "Horizontal";
        public static string KEYBOARD_VERTICAL = "Vertical";
        public static string ROTATION_AXIS = "Rotation";


        public static int LEFT_MOUSE_CLICKED = 0;
        public static int RIGHT_MOUSE_CLICKED = 1;
        public static int SCROLL_CLICKED = 2;
        public static float TERRAIN_TEMP_MIN_HEIGHT = -10;
        public static float TIME_OF_LONG_CLICK = 1;
        public static float TIME_OF_DOUBLE_CLICK = 1;
        public static float CLICK_DELAY = 0.5f;

        public const float MAX_RAY_DISTANCE = 500;
    }
}
