using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class BaseRiddle : BaseRaycastableItem
{
    [Header("BaserRiddle : Components")]
    [SerializeField] private BaseNote baseNote;

    public void SetBaseNote(int key)
    {
        baseNote.SetKeyValue(key);
    }
}
