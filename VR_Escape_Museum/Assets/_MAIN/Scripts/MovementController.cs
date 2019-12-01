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
    [SerializeField] private Transform player;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private GameObject handPrefab;
    [SerializeField] private GameObject coloredHandPrefab;
    [SerializeField] private float RayLenght = 3f;

    //private GameObject cursorInstance;
    //private GameObject teleportInstance;
    //private GameObject handInstance;
    //private GameObject coloredHandInstance;

    void Start()
    {
        Time.timeScale = 1;
        //cursorInstance = Instantiate(gameCursorPrefab);
        //teleportInstance = Instantiate(teleportPrefab);
        //handInstance = Instantiate(handPrefab);
        //coloredHandInstance = Instantiate(coloredHandPrefab);
        //cursorInstance.SetActive(true);
        //teleportInstance.SetActive(false);
        //handInstance.SetActive(false);
        //coloredHandInstance.SetActive(false);
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
        //Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
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
                gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
                gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
                Debug.Log("jestem tutaj i chuj");
                teleportPrefab.SetActive(false);
                gameCursorPrefab.SetActive(true);
            }
        }
        else
        {
            //Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.green);

            // If the ray doesn't hit anything, set the position to the maxCursorDistance and rotate to point away from the camera
            gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
            gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
        //Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward * 10);
        //RaycastHit hit;
        //Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, rayLenght))
        //    {
        //        teleportPrefab.SetActive(true);
        //        gameCursorPrefab.SetActive(false);
        //        teleportPrefab.transform.position = hit.point;
        //        teleportPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        //    }
        //    else
        //    {
        //        teleportPrefab.SetActive(false);
        //        gameCursorPrefab.SetActive(true);
        //    }
        //}
        //else
        //{
        //    gameCursorPrefab.SetActive(true);
        //    teleportPrefab.SetActive(false);
        //    gameCursorPrefab.transform.position = ray.origin + ray.direction.normalized;
        //    gameCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        //}
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