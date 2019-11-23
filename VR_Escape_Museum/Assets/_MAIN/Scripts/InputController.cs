using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public IMovement movementlistener;
    private InputValues inputs = new InputValues();
    public struct InputValues
    {
        public float xMouse;
        public float yMouse;

        public float xMousePos;
        public float yMousePos;
        public Vector3 mousePos;

        public float keyboardXAxis;
        public float keyboardYAxis;

        public float keyboardRotationAxis;

        public bool isWPressed;
        public bool isAPressed;
        public bool isSPressed;
        public bool isDPressed;

        public float scroll;
        public bool isQPressed;
        public bool isEPressed;
        public bool isEscPressed;
        public bool isScrollPressed;
        public bool isRightMousePressed;
        public bool isLeftMousePressed;

        public bool isLeftMouseUp;
        public bool isRightMouseUp;

    }
    public void InputUpdate()
    {
        inputs.xMouse = Input.GetAxisRaw(Keys.Inputs.MOUSE_X_AXIS);
        inputs.yMouse = Input.GetAxisRaw(Keys.Inputs.MOUSE_Y_AXIS);
        inputs.keyboardYAxis = Input.GetAxisRaw(Keys.Inputs.KEYBOARD_VERTICAL);
        inputs.keyboardXAxis = Input.GetAxisRaw(Keys.Inputs.KEYBOARD_HORIZONTAL);
        inputs.scroll = Input.GetAxisRaw(Keys.Inputs.MOUSE_SCROLL);

        inputs.xMousePos = Input.mousePosition.x;
        inputs.yMousePos = Input.mousePosition.y;
        inputs.mousePos = Input.mousePosition;

        inputs.isWPressed = Input.GetKey(KeyCode.W);
        inputs.isSPressed = Input.GetKey(KeyCode.S);
        inputs.isAPressed = Input.GetKey(KeyCode.A);
        inputs.isDPressed = Input.GetKey(KeyCode.D);
        inputs.isQPressed = Input.GetKey(KeyCode.Q);
        inputs.isEPressed = Input.GetKey(KeyCode.E);

        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);
        inputs.isScrollPressed = Input.GetMouseButton(Keys.Inputs.SCROLL_CLICKED);
        inputs.isRightMousePressed = Input.GetMouseButton(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButton(Keys.Inputs.LEFT_MOUSE_CLICKED);
        inputs.isLeftMouseUp = Input.GetMouseButtonUp(0);
        inputs.isRightMouseUp = Input.GetMouseButtonUp(1);
        movementlistener.UpdateAxis(inputs);
    }

    public InputValues GetInputValues()
    {
        return inputs;
    }
}
