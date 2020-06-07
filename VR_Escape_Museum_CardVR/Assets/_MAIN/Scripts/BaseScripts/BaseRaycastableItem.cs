using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRaycastableItem : MonoBehaviour
{
    [Header("BaseRaycastableItem: ")]
    [SerializeField] protected Outline outline;
    [SerializeField] protected List<Transform> spawnNoteLists = new List<Transform>();
    public List<Transform> SpawnNoteLists => spawnNoteLists;
    protected GameController gameController;

    private void Start()
    {
        if (outline != null) outline.enabled = false;
    }

    public virtual void OnRaycastEnter(GameController gameController)
    {
        if(outline != null) outline.enabled = true;

        this.gameController = gameController;
    }
    public virtual void OnRaycastStay(){}

    public virtual void OnRaycastExit()
    {
        outline.enabled = false;
        this.gameController = null;
    }

    public virtual void OnInterract()
    {
        outline.enabled = false;
    }
}
