﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRiddle : BaseRaycastableItem
{    public override void OnRaycastEnter()
    {
        base.OnRaycastEnter();
        Debug.Log("BaseRiddle :: OnRaycastEnter");
        outline.enabled = true;
    }
    public override void OnRaycastStay()
    {
        base.OnRaycastStay();
        Debug.Log("BaseRiddle :: OnRaycastStay");
    }

    public override void OnRaycastExit()
    {
        base.OnRaycastStay();
        Debug.Log("BaseRiddle :: OnRaycastExit");
        outline.enabled = false;
    }

    public override void OnInterract()
    {
        Debug.Log("BaseRiddle :: OnInterract");
    }
}
