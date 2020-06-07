using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class BaseNote : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private int keyValue;
    public int KeyValue => keyValue;

    public void SetKeyValue(int _keyValue, int number)
    {
        keyValue = _keyValue;
        text.text = number.ToString() + " - " + _keyValue.ToString();
    }
}
