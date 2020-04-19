using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasePickupable : BaseRiddle
{
    [SerializeField] protected string objectName;
    public string ObjectName => objectName;
}
