using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView {

    public IMenuView listener;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text duration;
    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetGameState()
    {
        listener.SetGameState();
    }

    public void SetMenuState(float gameTime)
    {
        mainPanel.SetActive(false);
        finishPanel.SetActive(true);
        menu.SetActive(true);
        game.SetActive(false);
        int minutes = 0, seconds = 0;

        minutes = ((int)gameTime / 60);
        seconds = ((int)gameTime % 60);

        duration.text = minutes.ToString() + " min " + seconds.ToString() + " s";
    }
}
