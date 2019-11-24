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
    //nowe
    private InputController.InputValues inputValues;
    //

    [SerializeField] private Camera viewCamera;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private GameObject handPrefab;
    [SerializeField] private GameObject coloredHandPrefab;
    [SerializeField] private float RayLenght = 3f;


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
            if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, RayLenght))
            {
                // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
                teleportPrefab.SetActive(true);
                gameCursorPrefab.SetActive(false);
                teleportPrefab.transform.position = hit.point;
                teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                teleportPrefab.SetActive(false);
                gameCursorPrefab.SetActive(true);
            }
        }
        else
        {
            // If the ray doesn't hit anything, set the position to the maxCursorDistance and rotate to point away from the camera
            gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
            gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
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
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }


}