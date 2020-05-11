﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetRiddle : BaseRiddle
{
    [SerializeField] private InteractableMisc miscsList;

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
    }
}
