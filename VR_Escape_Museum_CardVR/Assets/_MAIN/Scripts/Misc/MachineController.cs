using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : BaseInspectable
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
        gameController.EventsController.OnBuyItemEvent.Invoke();
    }
    #endregion

    public void OnBuyItemEvent()
    {
        Debug.Log("Invoked event, dropping cart");
    }
}
