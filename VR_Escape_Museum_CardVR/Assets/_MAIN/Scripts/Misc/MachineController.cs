﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : BaseRiddle
{
    [SerializeField] private GameObject card;

    private void Start()
    {
        card.SetActive(false);
    }

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
        if (gameController.DataController.Coin != null)
        {
            gameController.EventsController.OnBuyItemEvent.Invoke();
        }
    }
    #endregion

    public void OnBuyItemEvent()
    {
        card.SetActive(true);
    }
}
