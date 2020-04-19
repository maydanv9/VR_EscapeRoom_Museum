using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInspectable : BaseRaycastableItem
{
    public override void OnRaycastEnter(GameController gameController)
    {
        base.OnRaycastEnter(gameController);
    }

    public override void OnRaycastStay()
    {
        base.OnRaycastStay();
    }

    public override void OnRaycastExit()
    {
        base.OnRaycastStay();
    }

    public override void OnInterract()
    {
        base.OnInterract();
    }
}
