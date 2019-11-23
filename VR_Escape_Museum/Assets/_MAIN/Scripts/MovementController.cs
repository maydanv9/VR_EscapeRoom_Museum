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
    [SerializeField] private GameObject pauseObject;
    [SerializeField] private GameObject endGameObject;

    private GameObject cursorInstance;
    private GameObject teleportInstance;
    private GameObject handInstance;
    private GameObject coloredHandInstance;
    private bool pause = false;
    private static float a = -1.2f;
    private static float b = 1.5f;
    private static float c = 5.0f;
    Vector3 endPos = new Vector3(a, b, c);

    void Start()
    {
        Time.timeScale = 1;
        cursorInstance = Instantiate(gameCursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        handInstance = Instantiate(handPrefab);
        coloredHandInstance = Instantiate(coloredHandPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
        handInstance.SetActive(false);
        coloredHandInstance.SetActive(false);
        pauseObject.SetActive(false);
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
                if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, RayLenght))
                {
                    // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
                    teleportInstance.SetActive(true);
                    cursorInstance.SetActive(false);
                    teleportInstance.transform.position = hit.point;
                    teleportInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
                else
                {
                    teleportInstance.SetActive(false);
                    cursorInstance.SetActive(true);
                }
            }
            else
            {
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
        if (teleportInstance.activeInHierarchy)
        {
            Vector3 markerPosition = teleportInstance.transform.position;
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }


}