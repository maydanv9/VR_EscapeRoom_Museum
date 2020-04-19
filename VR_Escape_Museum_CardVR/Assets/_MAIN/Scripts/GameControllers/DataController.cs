using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private List<BasePickupable> pickedItems = new List<BasePickupable>();

    public void Init(GameController gameController)
    {
        this.gameController = gameController;
    }
    
    public void RegisterObject(BasePickupable basePickupable)
    {
        pickedItems.Add(basePickupable);
    }
}
