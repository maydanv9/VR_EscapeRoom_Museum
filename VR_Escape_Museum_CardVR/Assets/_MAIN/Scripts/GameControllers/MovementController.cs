using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System;
using System.IO;
using UnityEditor;


public class MovementController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Camera viewCamera;
    [SerializeField] private Transform player;
    //[SerializeField] private GameObject gameCursorPrefab;
    //[SerializeField] private GameObject initGameCursor;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private float rayLenght = 3f;

    private InputController.InputValues inputValues;
    private bool entered = false;
    [SerializeField] private BaseRaycastableItem currentfocusedObject;
    [SerializeField] private BaseRaycastableItem newBaseObject;
    enum objects { ground, interactable, empty };
    private objects currentObject;


    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void MovementUpdate(InputController.InputValues inputValues)
    {
        this.inputValues = inputValues;
        CheckInput();
        UpdateCursor();
    }

    private void UpdateCursor()
    {
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        SetCursors(true, false);
        currentObject = objects.empty;


        if (Physics.Raycast(ray, out hit, rayLenght))
        {
            try
            {
                newBaseObject = hit.collider.gameObject.GetComponent<BaseRaycastableItem>();
            }
            catch (NullReferenceException)
            {
                newBaseObject = null;
            }

            switch (hit.collider.tag)
            {
                case "Ground":
                    OnRaycastExitMethod();
                    Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
                    SetCursors(false, true);
                    teleportPrefab.transform.position = hit.point;
                    teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    currentObject = objects.ground;
                    break;
                case "Interactable":
                    if (newBaseObject == currentfocusedObject && currentfocusedObject != null)
                    {
                        currentfocusedObject.OnRaycastStay();
                    }
                    else if (newBaseObject != null && newBaseObject != currentfocusedObject)
                    {
                        currentfocusedObject = newBaseObject;
                        currentfocusedObject.OnRaycastEnter(gameController);
                        entered = true;
                        SetCursors(false, false);

                    }
                    currentObject = objects.interactable;
                    break;
                default:
                    OnRaycastExitMethod();
                    SetCursors(true, false);
                    currentObject = objects.empty;
                    break;
            }
        }

        //if (Physics.Raycast(ray, out hit, rayLenght))
        //{
        //    try
        //    {
        //        newBaseObject = hit.collider.gameObject.GetComponent<BaseRaycastableItem>();
        //        Debug.Log("T");

        //    }

        //    catch (NullReferenceException)
        //    {
        //        newBaseObject = null;
        //    }
        //}
            //if (newBaseObject == null && entered)
            //{
            //    if (currentfocusedObject != null)
            //    {
            //        currentfocusedObject.OnRaycastExit();
            //    }
            //    entered = false;
            //    currentfocusedObject = null;
            //}
        //}
        //else
        //{
        //    // if looking at nothing disable everything
        //    if (newBaseObject != null) newBaseObject.OnRaycastExit();
        //    entered = false;
        //    newBaseObject = null;
        //    currentfocusedObject = null;
        //}
    }
    private void OnRaycastExitMethod()
    {
        if (newBaseObject == null && currentfocusedObject != null)
        {
            currentfocusedObject.OnRaycastExit();
            currentfocusedObject = null;
        }
    }
    private void CheckInput()
    {
        if (inputValues.isLeftMousePressed || inputValues.isPadAPressed)
        {
            switch (currentObject)
            {
                case objects.ground:
                    gameController.GroundController.TeleportPlayer(teleportPrefab.transform.position);
                    break;
                case objects.interactable:
                    currentfocusedObject.OnInterract();
                    gameController.EventsController.AlarmEvent.Invoke();
                    entered = false;
                    break;
                case objects.empty:
                    break;
            }
        }
    }

    public void SetCursors(bool valueGameCursor, bool valueTeleportPrefab)
    {
        //gameCursorPrefab.SetActive(valueGameCursor);
        teleportPrefab.SetActive(valueTeleportPrefab);
    }
}