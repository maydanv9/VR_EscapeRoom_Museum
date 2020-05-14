using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private List<BasePickupable> pickedItems = new List<BasePickupable>();
    public List<BasePickupable> PickedItems => pickedItems;
    private Pickupable_Coin coin;
    private Pickupable_Key key;

    public Pickupable_Coin Coin => coin;
    public Pickupable_Key Key => key;

    public void Init(GameController gameController)
    {
        this.gameController = gameController;
    }
    
    public void RegisterObject(BasePickupable basePickupable)
    {
        pickedItems.Add(basePickupable);
        switch (basePickupable)
        {
            case Pickupable_Key key:
                this.key = key;
                break;
            case Pickupable_Coin coin:
                this.coin = coin;
                break;
        }
    }

    public bool CheckObject(BasePickupable basePickupable)
    {
        if (pickedItems.Contains(basePickupable)) return true;
        else return false;
    }
}
