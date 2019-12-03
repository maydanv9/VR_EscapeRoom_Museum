using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectRiddle : BaseRiddle
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
        base.OnRaycastExit();
    }

    public override void OnInterract()
    {
        base.OnInterract();
        gameController.GroundController.TeleportPlayerToInspectingRoom();
        gameController.ExamineSystem.ClickObject(this.gameObject);
        outline.enabled = false;
    }
}
