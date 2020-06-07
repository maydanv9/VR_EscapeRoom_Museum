using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class BaseRiddle : BaseRaycastableItem
{
    [Header("BaseRiddle : Components")]
    [ReadOnly] [SerializeField] private BaseNote baseNote;

    public void SetBaseNote(int key, BaseNote note, int number)
    {
        baseNote = note;
        baseNote.SetKeyValue(key, number);
        SetNotePosition();
    }
    private void SetNotePosition()
    {
        var randomInt = Random.Range(0, spawnNoteLists.Count);
        baseNote.gameObject.transform.parent = spawnNoteLists[randomInt];
        baseNote.transform.position = new Vector3(0, 0, 0);
        baseNote.transform.localPosition = new Vector3(0, 0, 0);
        baseNote.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
