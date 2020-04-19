using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsController : MonoBehaviour
{
    private GameController gameController;
    public PickupEvent OnObjectCollectedEvent;
    public NotificationEvent OnNotificationShowEvent;
    public List<UnityEvent> unityEvents = new List<UnityEvent>();
    public void Init(GameController gameController)
    {
        this.gameController = gameController;
        OnObjectCollectedEvent.AddListener(OnObjectPickedUp);
        OnNotificationShowEvent.AddListener(OnNotificationShow);
        //onObjectPickedUp.AddListener(delegate { OnObjectPickedUp(); });
    }
    public void OnObjectPickedUp(BasePickupable pickedObject)
    {
        gameController.DataController.RegisterObject(pickedObject);
        pickedObject.gameObject.SetActive(false);
        OnNotificationShowEvent.Invoke(pickedObject);
    }
    public void OnNotificationShow(BasePickupable pickedObject)
    {
        gameController.UIController.GameView.NotificationView.Notify(pickedObject.ObjectName);
    }
}
