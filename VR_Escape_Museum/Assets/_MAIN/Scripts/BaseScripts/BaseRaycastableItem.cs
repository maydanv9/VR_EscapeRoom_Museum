using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRaycastableItem : MonoBehaviour
{
    [Header("BaseRaycastableItem: ")]
    [SerializeField] protected Outline outline;

    public virtual void OnRaycastStay() { }
    public virtual void OnRaycastEnter(GameController gameController) { }
    public virtual void OnRaycastExit() { }
    public virtual void OnInterract() { }
}
