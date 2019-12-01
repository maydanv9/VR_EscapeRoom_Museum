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
    enum objects { ground, interactable, empty };
    private objects currentObject;
    private InputController.InputValues inputValues;
    private bool entered = false;
    private bool canExit = false;

    [SerializeField] private Camera viewCamera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pointersParent;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;   
    [SerializeField] private GameObject focusedObject;
    
    private float rayLenght = 3f;
    private GameObject cursorInstance;

    void Start()
    {
        cursorInstance = Instantiate(gameCursorPrefab, pointersParent);
        Destroy(gameCursorPrefab);
    }

    public void MovementUpdate(InputController.InputValues inputValues)
    {
        this.inputValues = inputValues;
        UpdateCursor();
        CheckInput();
    }

    private void UpdateCursor()
    {
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLenght))
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
                teleportPrefab.SetActive(true);
                cursorInstance.SetActive(false);
                teleportPrefab.transform.position = hit.point;
                teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                currentObject = objects.ground;
            }
            else if (hit.collider.tag == "Interactable")
            {
                currentObject = objects.interactable;
                var hitReciver = hit.collider.gameObject.GetComponent<BaseRiddle>();

                if (hit.collider.gameObject.GetComponent<BaseRiddle>() != null)
                {
                    if (!entered)
                    {
                        hitReciver.OnRaycastEnter();
                        entered = true;
                        canExit = true;
                        focusedObject = hit.collider.gameObject;
                    }
                    else if (entered)
                    {
                        hitReciver.OnRaycastStay();
                    }
                } else if (canExit)
                {
                    focusedObject.GetComponent<BaseRaycastableItem>().OnRaycastExit();
                    canExit = false;
                    entered = false;
                }

            }
            else
            {
                Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.green);
                teleportPrefab.SetActive(false);
                cursorInstance.SetActive(true);
                cursorInstance.transform.position = ray.origin + ray.direction.normalized;
                cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
                currentObject = objects.empty;
            }
        }
        else
        {
            teleportPrefab.SetActive(false);
            cursorInstance.SetActive(true);
            Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.blue);
            cursorInstance.transform.position = ray.origin + ray.direction.normalized;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
    }
    
    private void CheckInput()
    {
        if (inputValues.isLeftMousePressed)
        {
            switch (currentObject)
            {
                case objects.ground:
                    Teleport();
                    break;
                case objects.interactable:
                    Debug.Log("interactring with");
                    break;
                case objects.empty:
                    break;
            }
        }
    }

    public void Teleport()
    {
        if (teleportPrefab.activeInHierarchy)
        {
            Vector3 markerPosition = teleportPrefab.transform.position;
            player.position = new Vector3(markerPosition.x, player.position.y, markerPosition.z);
        }
    }


}