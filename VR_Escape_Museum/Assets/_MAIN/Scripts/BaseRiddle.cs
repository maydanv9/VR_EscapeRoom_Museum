using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRiddle : BaseRaycastableItem
{
    private bool isRaycasted;
    [SerializeField] private Outline outline;

    public override void OnRaycastEnter()
    {
        Debug.Log("RaycastEnter");
    }
    public override void OnRaycastStay()
    {
        Debug.Log("RaycastStay");

    }

    public override void OnRaycastExit()
    {
        Debug.Log("RaycastExit");

    }

}
