using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable_Key : BasePickupable
{
    #region ------ INTERACTIONS ------
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
        base.OnRaycastExit();
    }

    public override void OnInterract()
    {
        base.OnInterract();
        gameController.EventsController.OnObjectCollectedEvent.Invoke(this);
    }
    #endregion
}
