using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView {

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.GameView.listener = this;
        this.gameController.UIController.GameView.ShowView();

    }

    public override void UpdateState(GameController gameController)
    {
        Debug.Log("GameState :: UpdateState()");
    }

    public override void DeinitState(GameController gameController)
    {
        base.DeinitState(gameController);
        this.gameController.UIController.GameView.listener = null;
        this.gameController.UIController.GameView.HideView();
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());
        
    }
}
