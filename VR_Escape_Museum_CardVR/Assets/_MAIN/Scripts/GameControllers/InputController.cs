using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public IMovement movementlistener;
    private InputValues inputs = new InputValues();
    public struct InputValues
    {
        public bool isEscPressed;
        public bool isRightMousePressed;
        public bool isLeftMousePressed;
    }
    public void InputUpdate()
    {
        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);
        inputs.isRightMousePressed = Input.GetMouseButtonDown(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButtonDown(Keys.Inputs.LEFT_MOUSE_CLICKED);
        movementlistener.UpdateAxis(inputs);
    }

    public InputValues GetInputValues()
    {
        return inputs;
    }
}
