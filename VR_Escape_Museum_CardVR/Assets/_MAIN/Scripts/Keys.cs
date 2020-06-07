using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{    public static class Inputs
    {
        public static int LEFT_MOUSE_CLICKED = 0;
        public static int RIGHT_MOUSE_CLICKED = 1;
    }
    public static class Tags
    {
        public static string DEFAULT_TAG = "Untagged";
        public static string INTERACTABLE_TAG = "Interactable";
    }
    public static class Items
    {
        public static string KEY = "Key";
        public static string COIN = "Coin";
        public static string CARD = "Card";
        public static string DOOR = "Door";
    }
    public static class Animaitons
    {
        public static string ANIMATION = "ANIMATION";
    }

    public static class Sounds
    {
        public static string SOUND_STEP = "Sound step";
    }
}
