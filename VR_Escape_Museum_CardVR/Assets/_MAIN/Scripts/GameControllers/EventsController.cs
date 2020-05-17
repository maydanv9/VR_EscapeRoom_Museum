using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsController : MonoBehaviour
{
    private GameController gameController;
    public PickupEvent OnObjectCollectedEvent;
    public NotificationEvent OnNotificationShowEvent;
    public UnityEvent OnBuyItemEvent;
    public UnityEvent AlarmEvent;
    public List<UnityEvent> unityEvents = new List<UnityEvent>();
    public void Init(GameController gameController)
    {
        this.gameController = gameController;
        OnObjectCollectedEvent.AddListener(OnObjectPickedUp);
        OnNotificationShowEvent.AddListener(OnNotificationShow);
        OnBuyItemEvent.AddListener(delegate { OnBuyItem(); });
        AlarmEvent.AddListener(delegate { OnAlarmEvent(); });
    }
    public void OnObjectPickedUp(BasePickupable pickedObject)
    {
        gameController.DataController.RegisterObject(pickedObject);
        pickedObject.gameObject.SetActive(false);
        OnNotificationShowEvent.Invoke(pickedObject);
    }
    public void OnNotificationShow(BasePickupable pickedObject)
    {
        gameController.UIController.GameView.NotificationView.Notify(pickedObject);
    }

    public void OnBuyItem()
    {
        foreach(BasePickupable item in gameController.DataController.PickedItems)
        {
            if (item is Pickupable_Coin)
            {
                gameController.MachineController.OnBuyItemEvent();
                gameController.DataController.PickedItems.Remove(item);
                return;
            }
        }
    }

    public void OnAlarmEvent()
    {
        gameController.AlarmController.OnAlarmEnabled();
    }
}
