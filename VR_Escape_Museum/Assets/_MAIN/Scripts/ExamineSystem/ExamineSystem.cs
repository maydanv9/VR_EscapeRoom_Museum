using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineSystem : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera mainCam; 
    [SerializeField] GameObject examineCanvas;
    GameObject clickedObject;

    [SerializeField] Button upButton;
    [SerializeField] Button downButton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button exitButton;

    private InputController.InputValues inputValues;

    //Holds Original Postion And Rotation So The Object Can Be Replaced Correctly
    Vector3 objectOriginalPosition;
    Vector3 objectOriginalRotation;

    Vector3 playerOriginalPosition;
    Vector3 playerOriginalRotation;

    //If True Allow Rotation Of Object
    bool examineMode = false;
    private float rotation = 10.0f;

    void Start() {
        
        mainCam = Camera.main;
        examineMode = false;

        upButton.onClick.AddListener(RotateUp);
        downButton.onClick.AddListener(RotateDown);
        leftButton.onClick.AddListener(RotateLeft);
        rightButton.onClick.AddListener(RotateRight);
        exitButton.onClick.AddListener(ExitExamineMode);

    }

    private void Update() {
        ClickObject();
    }



    public void ClickObject() {
        
            if(examineMode ==false && Input.GetMouseButtonDown(0) ) { 
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit)) {
                //ClickedObject Will Be The Object Hit By The Raycast
                clickedObject = hit.transform.gameObject;


                objectOriginalPosition = clickedObject.transform.position;
                objectOriginalRotation = clickedObject.transform.rotation.eulerAngles;
                playerOriginalPosition = player.transform.position;
                playerOriginalRotation = player.transform.rotation.eulerAngles;

                //Move player to location used to inspect items
                player.transform.position = new Vector3(-20, 1, -1);
                mainCam.transform.localEulerAngles = new Vector3(0, 0, 0);


                clickedObject.transform.position = player.transform.position - (transform.forward * 1.4f);


                examineCanvas.SetActive(true);

                examineMode = true;
            }
        }
    }

    //temp
    private void RotateUp( ) {

        clickedObject.transform.Rotate(-rotation, 0, 0, Space.Self);

    }

    private void RotateDown( ) {

        clickedObject.transform.Rotate(rotation, 0,0,Space.Self);

    }
    private void RotateLeft( ) {

        clickedObject.transform.Rotate(0, rotation, 0, Space.Self);

    }
    private void RotateRight( ) {

        clickedObject.transform.Rotate(0, -rotation, 0, Space.Self);

    }


    void ExitExamineMode() {
        if( examineMode) {
            
            clickedObject.transform.position = objectOriginalPosition;
            clickedObject.transform.eulerAngles = objectOriginalRotation;
            player.transform.position = playerOriginalPosition;
            player.transform.eulerAngles = playerOriginalRotation;

            examineCanvas.SetActive(false);
            examineMode = false;
        }
    }
}