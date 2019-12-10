using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineSystem : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Transform examineRoomTransform;
    [SerializeField] private Transform examineRoomInspectTransform ;
    [SerializeField] private float scaleValue;
   


    private GameObject oldInspectedObject;
    private GameObject clickedObject;
    private Vector3 clickedObjectBasicRotation;
    private static float rotation = 10.0f;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void SelectObject(GameObject inspectedObject/* , bool objectRotated) */)
    {
        //if(objectRotated)
        //{
        //    //Making parent the inspected object as new gameObject 
        //    inspectedObject = inspectedObject.transform.parent.gameObject;
        //}
        if(clickedObject != null)
        {
            oldInspectedObject = clickedObject;
            oldInspectedObject.SetActive(false);
        }
        clickedObject = Instantiate(inspectedObject, examineRoomTransform);
        SetupObject( /*objectRotated */);
        gameController.SceneReferences.ExamineRoom.SetActive(true);
        gameController.UIController.ExamineView.enabled = true;
    }

    private void SetupObject(/*bool objectRotated */)
    {
        clickedObject.tag = Keys.Tags.DEFAULT_TAG;
        //var objectCollider = (objectRotated) ? clickedObject.GetComponentInChildren<Collider>() : clickedObject.GetComponent<Collider>();
        var objectCollider = clickedObject.GetComponent<Collider>();
        objectCollider.enabled = false;
        clickedObject.transform.localPosition = new Vector3(0, 1, -3.5f);
        clickedObjectBasicRotation = clickedObject.transform.localEulerAngles;
        ResetScale();
        ResetRotation();
    }

    #region BUTTONS
    public void ExitExamineMode()
    {
        if(oldInspectedObject != null)
        {
            Destroy(oldInspectedObject);
        }
        Destroy(clickedObject);
        //gameController.MovementController.getNulledBaseObject();
        //gameController.MovementController.getNulledFocusedObject();
        gameController.GroundController.TeleportPlayerToGame();
    }

    public void ReturnToOldInspectedObject()
    {
        if(oldInspectedObject != null)
        {
            Destroy(clickedObject);
            clickedObject = oldInspectedObject;
            clickedObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            clickedObject.SetActive(true);
        }
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
        if(ZoomLimiter(clickedObject) < 3.0f)
        clickedObject.transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void ScaleDown()
    {
        if(ZoomLimiter(clickedObject) > 1.0f)
            clickedObject.transform.localScale -= new Vector3(scaleValue, scaleValue, scaleValue);
        else if(ZoomLimiter(clickedObject) >= 0.5f)
            clickedObject.transform.localScale -= new Vector3(scaleValue / 2, scaleValue / 2, scaleValue / 2);
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

    private float ZoomLimiter(GameObject clickedObject)
    {
        return clickedObject.transform.localScale.x;
    }

    #endregion
}