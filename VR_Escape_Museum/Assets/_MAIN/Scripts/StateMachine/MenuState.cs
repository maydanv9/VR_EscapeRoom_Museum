﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView, IMovement
{

    private InputController.InputValues inputs;

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.MenuView.listener = this;
        this.gameController.UIController.MenuView.ShowView();
    }

    public override void UpdateState(GameController gameController)
    {
        this.gameController.MovementController.MovementUpdate(inputs);
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

    #region INTERFACES
    public void UpdateAxis(InputController.InputValues inputValues)
    {
        inputs = inputValues;
    }
    #endregion
}
