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
    [SerializeField] private Camera viewCamera;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private GameObject handPrefab;
    [SerializeField] private GameObject coloredHandPrefab;
    [SerializeField] private float rayLenght = 3f;

    private InputController.InputValues inputValues;
    private bool entered = false;
    private bool canExit = false;
    private GameObject focusedObject;
    private BaseRiddle currentBaseObject;
    enum objects { ground, interactable, empty };
    private objects currentObject;

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
                gameCursorPrefab.SetActive(false);
                teleportPrefab.transform.position = hit.point;
                teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                currentObject = objects.ground;
            }
            else if (hit.collider.tag == "Interactable")
            {
                currentObject = objects.interactable;
                currentBaseObject = hit.collider.gameObject.GetComponent<BaseRiddle>();

                if (hit.collider.gameObject.GetComponent<BaseRiddle>() != null)
                {
                    if (!entered)
                    {
                        currentBaseObject.OnRaycastEnter();
                        entered = true;
                        canExit = true;
                        focusedObject = hit.collider.gameObject;
                    }
                    else if (entered)
                    {
                        currentBaseObject.OnRaycastStay();
                    }
                }
                else if (canExit)
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
                gameCursorPrefab.SetActive(true);
                gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
                gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
                currentObject = objects.empty;
            }
        }
        else
        {
            teleportPrefab.SetActive(false);
            gameCursorPrefab.SetActive(true);
            Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.blue);
            gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
            gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
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
                    currentBaseObject.OnInterract();
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