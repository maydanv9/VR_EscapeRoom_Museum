﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView {


    [SerializeField] private NotificationView notificationView;
    public NotificationView NotificationView => notificationView;

    public IGameView listener;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetMenuState()
    {
        listener.SetMenuState();
    }


}
