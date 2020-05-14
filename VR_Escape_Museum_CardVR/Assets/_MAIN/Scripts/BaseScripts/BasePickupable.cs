using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class BasePickupable : BaseRiddle
{
    [ReadOnly] [SerializeField] protected string objectName;
    public string ObjectName => objectName;

    private bool isCollected;
    public bool IsCollected => isCollected;

    public virtual void Collect()
    {
        isCollected = true;
    }
}
