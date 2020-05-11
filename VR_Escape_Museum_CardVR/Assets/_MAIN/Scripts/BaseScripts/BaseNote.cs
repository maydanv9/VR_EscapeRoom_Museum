using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseNote : MonoBehaviour
{
    private int keyValue;
    public int KeyValue => keyValue;

    public void SetKeyValue(int _keyValue)
    {
        keyValue = _keyValue;
    }
}
