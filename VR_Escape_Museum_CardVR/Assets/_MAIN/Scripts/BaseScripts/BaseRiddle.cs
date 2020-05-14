using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class BaseRiddle : BaseRaycastableItem
{
    [Header("BaseRiddle : Components")]
    [ReadOnly] [SerializeField] private BaseNote baseNote;

    public void SetBaseNote(int key, BaseNote note)
    {
        baseNote = note;
        baseNote.SetKeyValue(key);
        SetNotePosition();
    }
    private void SetNotePosition()
    {
        var randomInt = Random.Range(0, spawnNoteLists.Count);
        baseNote.gameObject.transform.parent = spawnNoteLists[randomInt];
        baseNote.gameObject.transform.position = spawnNoteLists[randomInt].position;
    }
}
