using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineSystem : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Transform examineRoomTransform;
    [SerializeField] private float scaleValue;


    private GameObject clickedObject;
    private Vector3 clickedObjectBasicRotation;
    private static float rotation = 10.0f;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void SelectObject(GameObject inspectedObject,bool objectRotated)
    {
        if(objectRotated)
        {
            //Making parent the inspected object as new gameObject 
            inspectedObject = inspectedObject.transform.parent.gameObject;
        }
        clickedObject = Instantiate(inspectedObject, examineRoomTransform);
        SetupObject(objectRotated);
        gameController.SceneReferences.ExamineRoom.SetActive(true);
        gameController.UIController.ExamineView.enabled = true;
    }

    private void SetupObject(bool objectRotated)
    {
        clickedObject.tag = Keys.Tags.DEFAULT_TAG;
        var objectCollider = (objectRotated) ? clickedObject.GetComponentInChildren<Collider>() : clickedObject.GetComponent<Collider>();
        objectCollider.enabled = false;
        clickedObject.transform.localPosition = new Vector3(0, 1, -3.5f);
        clickedObjectBasicRotation = clickedObject.transform.localEulerAngles;
        ResetScale();
        ResetRotation();
    }

    #region BUTTONS
    public void ExitExamineMode()
    {
        Destroy(clickedObject);
        gameController.GroundController.TeleportPlayerToGame();
    }

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

    public void ScaleUp()
    {
        clickedObject.transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void ScaleDown()
    {
        clickedObject.transform.localScale -= new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void ResetScale()
    {
        clickedObject.transform.localScale = new Vector3(1, 1, 1);
        ResetRotation();
    }

    private void ResetRotation()
    {
        clickedObject.transform.localEulerAngles = clickedObjectBasicRotation;
    }
    #endregion
}