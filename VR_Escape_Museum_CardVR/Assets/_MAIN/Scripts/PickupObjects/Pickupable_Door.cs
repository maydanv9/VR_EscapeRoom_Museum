using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable_Door : BasePickupable
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
        gameController.EventsController.FinishEvent.Invoke();
    }
    #endregion
    private void OnValidate() => this.objectName = Keys.Items.DOOR;

}
