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
    private InputController.InputValues inputValues;    

    [SerializeField] private Camera viewCamera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pointersParent;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;   
    
    private float RayLenght = 3f;
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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
            if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, RayLenght))
            {
                // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
                teleportPrefab.SetActive(true);
                cursorInstance.SetActive(false);
                teleportPrefab.transform.position = hit.point;
                teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                teleportPrefab.SetActive(false);
                cursorInstance.SetActive(true);
                cursorInstance.transform.position = ray.origin + ray.direction.normalized;
                cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
            }
        }
        else
        {
            Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.green);
            // If the ray doesn't hit anything, set the position to the maxCursorDistance and rotate to point away from the camera
            cursorInstance.transform.position = ray.origin + ray.direction.normalized;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
    }

    private void CheckInput()
    {
        if (inputValues.isLeftMousePressed)
        {
            Teleport();
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