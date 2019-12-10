using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class BaseRiddle : BaseRaycastableItem
{
    protected GameController gameController;

    public override void OnRaycastEnter(GameController gameController)
    {
        base.OnRaycastEnter(gameController);
        outline.enabled = true;
        this.gameController = gameController;
    }
    public override void OnRaycastStay()
    {
        base.OnRaycastStay();
    }

    public override void OnRaycastExit()
    {
        base.OnRaycastExit();
        outline.enabled = false;
        this.gameController = null;
    }

    public override void OnInterract()
    {
        base.OnInterract();
        outline.enabled = false;
    }
}
