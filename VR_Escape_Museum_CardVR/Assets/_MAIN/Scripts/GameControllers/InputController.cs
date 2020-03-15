using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public IMovement movementlistener;
    [SerializeField] private InputValues inputs = new InputValues();

    [System.Serializable]
    public struct InputValues
    {
        public bool isEscPressed;
        public bool isRightMousePressed;
        public bool isLeftMousePressed;
        public bool isPadAPressed;
    }

    public void InputUpdate()
    {
        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);
        inputs.isRightMousePressed = Input.GetMouseButtonDown(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButtonDown(Keys.Inputs.LEFT_MOUSE_CLICKED);
        inputs.isPadAPressed = Input.GetKey("joystick button 0");
        movementlistener.UpdateAxis(inputs);
    }

    public InputValues GetInputValues()
    {
        return inputs;
    }
}
