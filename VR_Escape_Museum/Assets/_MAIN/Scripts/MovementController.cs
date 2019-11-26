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
    [SerializeField] private float rayLenght = 2f;


    public void MovementUpdate(InputController.InputValues inputValues)
    {
        this.inputValues = inputValues;
        UpdateCursor();
        CheckInput();
    }

    private void UpdateCursor()
    {
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward * 10);
        RaycastHit hit;
        Debug.DrawRay(viewCamera.transform.position, viewCamera.transform.forward * 10, Color.red);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, rayLenght))
            {
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
            gameCursorPrefab.SetActive(true);
            teleportPrefab.SetActive(false);
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
            player.position = new Vector3(markerPosition.x, player.position.y, markerPosition.z);
        }
    }


}