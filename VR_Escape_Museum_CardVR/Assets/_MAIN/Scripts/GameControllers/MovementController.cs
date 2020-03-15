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
    [SerializeField] private BaseRaycastableItem focusedObject;
    [SerializeField] private BaseRaycastableItem currentBaseObject;
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

        if(Physics.Raycast(ray, out hit, rayLenght))
            {
            if(hit.collider.tag == "Ground") 
                {
                Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
                SetCursors(false, true);
                teleportPrefab.transform.position = hit.point;
                teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                currentObject = objects.ground;
            } 
            else if(hit.collider.tag == "Interactable") 
                {
                if(currentBaseObject == focusedObject && focusedObject != null)
                {
                    focusedObject.OnRaycastStay();
                } 
                else if(currentBaseObject != null && !entered)
                {
                    focusedObject = currentBaseObject;
                    focusedObject.OnRaycastEnter(gameController);
                    entered = true;
                    SetCursors(false, false);
                }
                currentObject = objects.interactable;
            }
            else
            {
                SetCursors(true, false);
                Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.blue);
                //gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
                //gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
                currentObject = objects.empty;
            }
        }
        else
        {
            SetCursors(true, false);
            Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.blue);
            //gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
            //gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
            currentObject = objects.empty;
        }

        if (Physics.Raycast(ray, out hit, rayLenght*2))
        {
            try
            {
                currentBaseObject = hit.collider.gameObject.GetComponent<BaseRaycastableItem>();      
            }

            catch (NullReferenceException)
            {
            }

            if (currentBaseObject == null && entered)
            {
                if(focusedObject != null)
                {
                    focusedObject.OnRaycastExit();
                }
                entered = false;
                focusedObject = null;
            }
        }
        else
        {
            // if looking at nothing disable everything
            if(currentBaseObject != null)
            currentBaseObject.OnRaycastExit();
            entered = false;
            currentBaseObject = null;
            focusedObject = null;
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
                    focusedObject.OnInterract();
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