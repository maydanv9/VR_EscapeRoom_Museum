using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectRiddle : BaseRiddle
{
    private UnityEvent examineEvent;
    //Delete after fixing object rotations
    //[SerializeField] private bool isObjectRotated;

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
        //gameController.ExamineSystem.SelectObject(this.gameObject,this.isObjectRotated);
        gameController.ExamineSystem.SelectObject(this.gameObject);
    }

}
