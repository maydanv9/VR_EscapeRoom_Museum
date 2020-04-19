using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationView : BaseView
{
    [SerializeField] private TMP_Text text;

    public void Notify(string name)
    {
        text.text = name;
        ShowAndHide();
    }

    public override void ShowAndHide()
    {
        base.ShowAndHide();
    }
}
