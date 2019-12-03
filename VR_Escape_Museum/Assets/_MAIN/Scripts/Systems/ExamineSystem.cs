using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineSystem : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject examineCanvas;

    private GameObject clickedObject;

    private InputController.InputValues inputValues;

    private Vector3 objectOriginalPosition;
    private Vector3 objectOriginalRotation;

    private Vector3 playerOriginalPosition;
    private Vector3 playerOriginalRotation;

    private static float rotation = 10.0f;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void ClickObject(GameObject inspectedObject)
    {
        //TODO instantiate GO and work on instanitated object
        clickedObject = inspectedObject;
        objectOriginalPosition = clickedObject.transform.position;
        objectOriginalRotation = clickedObject.transform.rotation.eulerAngles;
        playerOriginalPosition = player.transform.position;
        playerOriginalRotation = player.transform.rotation.eulerAngles;
        clickedObject.transform.position = player.transform.position - (transform.forward * 1.4f);
        gameController.SceneReferences.ExamineRoom.SetActive(true);
        gameController.UIController.ExamineView.enabled = true;
    }

    public void ExitExamineMode()
    {
        clickedObject.transform.position = objectOriginalPosition;
        clickedObject.transform.eulerAngles = objectOriginalRotation;

        gameController.GroundController.TeleportPlayerToGame();
    }
    #region BUTTONS
    public void RotateUp()
    {
        clickedObject.transform.Rotate(-rotation, 0, 0, Space.Self);
    }

    public void RotateDown()
    {
        clickedObject.transform.Rotate(rotation, 0, 0, Space.Self);
    }
    public void RotateLeft()
    {
        clickedObject.transform.Rotate(0, rotation, 0, Space.Self);
    }    

    public void RotateRight()
    {
        clickedObject.transform.Rotate(0, -rotation, 0, Space.Self);
    }
    #endregion
}