using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRaycastableItem : MonoBehaviour
{
    [Header("BaseRaycastableItem: ")]
    [SerializeField] protected Outline outline;

    public virtual void OnRaycastStay()
    {
        Debug.Log("BaseRaycastableItem :: OnRaycastStay");
    }

    public virtual void OnRaycastEnter()
    {
        Debug.Log("BaseRaycastableItem :: OnRaycastEnter");

    }
    public virtual void OnRaycastExit()
    {
        Debug.Log("BaseRaycastableItem :: OnRaycastExit");
    }

    public virtual void OnInterract()
    {
        Debug.Log("BaseRaycastableItem :: OnInterract");
    }
}
