using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationView : BaseView
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform player;
    public void Notify(BasePickupable pickedObject)
    {
        text.text = pickedObject.ObjectName;
        canvas.transform.localPosition = new Vector3(pickedObject.transform.position.x, pickedObject.transform.position.y + 1, pickedObject.transform.position.z);
        canvas.transform.LookAt(player, Vector3.zero);
        ScaleUpAndShow();
    }

    public override void ScaleUpAndShow()
    {
        base.ScaleUpAndShow();
    }
}