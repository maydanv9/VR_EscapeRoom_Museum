using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView {
    [SerializeField] private Text mainText;
    public IMenuView listener;


    public override void ShowView()
    {
        base.ShowView();
        mainText.text = "MenuView";
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetGameState()
    {
        listener.SetGameState();
    }
}
