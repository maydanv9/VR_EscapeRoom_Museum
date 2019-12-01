using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView {

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.MenuView.listener = this;
        this.gameController.UIController.MenuView.ShowView();
    }

    public override void UpdateState(GameController gameController)
    {

    }

    public override void DeinitState(GameController gameController)
    {
        base.DeinitState(gameController);
        this.gameController.UIController.MenuView.listener = null;
        this.gameController.UIController.MenuView.HideView();
    }

    public void SetGameState()
    {
        gameController.ChangeState(new GameState());
    }
}
