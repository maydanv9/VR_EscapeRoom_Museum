using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInspectable : BaseRaycastableItem
{
    public override void OnRaycastEnter(GameController gameController)
    {
        base.OnRaycastEnter(gameController);
        outline.enabled = true;
    }

    public override void OnRaycastStay()
    {
        base.OnRaycastStay();
    }

    public override void OnRaycastExit()
    {
        base.OnRaycastStay();
        outline.enabled = false;
    }

    public override void OnInterract()
    {
        base.OnInterract();
    }
}
