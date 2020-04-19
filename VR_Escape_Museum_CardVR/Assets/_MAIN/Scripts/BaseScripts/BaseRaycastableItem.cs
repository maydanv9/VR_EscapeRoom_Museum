using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRaycastableItem : MonoBehaviour
{
    [Header("BaseRaycastableItem: ")]
    [SerializeField] protected Outline outline;

    //public virtual void OnRaycastStay() { }
    //public virtual void OnRaycastEnter(GameController gameController) { }
    //public virtual void OnRaycastExit() { }
    //public virtual void OnInterract() { }

    protected GameController gameController;

    public virtual void OnRaycastEnter(GameController gameController)
    {
        outline.enabled = true;
        this.gameController = gameController;
    }
    public virtual void OnRaycastStay()
    {
    }

    public virtual void OnRaycastExit()
    {
        outline.enabled = false;
        this.gameController = null;
    }

    public virtual void OnInterract()
    {
        outline.enabled = false;
    }
}
