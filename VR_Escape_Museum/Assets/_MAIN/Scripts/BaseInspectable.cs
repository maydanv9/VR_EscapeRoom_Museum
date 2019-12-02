using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInspectable : BaseRaycastableItem
{
    public override void OnRaycastEnter()
    {
        base.OnRaycastEnter();
        Debug.Log("BaseInspectable  :: OnRaycastEnter");
        outline.enabled = true;
    }
    public override void OnRaycastStay()
    {
        base.OnRaycastStay();
        Debug.Log("BaseInspectable  :: OnRaycastStay");
    }

    public override void OnRaycastExit()
    {
        base.OnRaycastStay();
        Debug.Log("BaseInspectable  :: OnRaycastExit");
        outline.enabled = false;
    }

    public override void OnInterract()
    {
        Debug.Log("BaseInspectable  :: OnInterract");
    }
}
