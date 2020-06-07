using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    public UIController UIController { get { return uiController; } }

    [SerializeField] private InputController inputController;
    public InputController InputController { get { return inputController; } }

    [SerializeField] private MovementController movementController;
    public MovementController MovementController { get { return movementController; } }

    [SerializeField] private SceneReferences sceneReferences;
    public SceneReferences SceneReferences { get { return sceneReferences; } }

    [SerializeField] private GroundController groundController;
    public GroundController GroundController { get { return groundController; } }

    [SerializeField] private ExamineSystem examineSystem;
    public ExamineSystem ExamineSystem { get { return examineSystem; } }

    [SerializeField] private RiddleSpawner riddleSpawner;
    public RiddleSpawner RiddleSpawner { get { return riddleSpawner; } }

    [SerializeField] private DataController dataController;
    public DataController DataController => dataController;

    [SerializeField] private EventsController eventsController;
    public EventsController EventsController => eventsController;

    [SerializeField] private MachineController machineController;
    public MachineController MachineController => machineController;

    [SerializeField] private PinPadController pinPadController;
    public PinPadController PinPadController => pinPadController;

    [SerializeField] private AlarmController alarmController;
    public AlarmController AlarmController => alarmController;

    [SerializeField] private SoundController soundController;
    public SoundController SoundController => soundController;
    [SerializeField] private TimeController timeController;
    public TimeController TimeController => timeController;
    private void Awake()
    {
        Initialization();
        AssignAnalytics();
    }

    void Initialization()
    {
        ChangeState(new MenuState());
    }

    void AssignAnalytics()
    {

    }

    BaseState currrentState;

    public void ChangeState(BaseState newState)
    {
        if (currrentState != null)
        {
            currrentState.DeinitState(this);
        }

        currrentState = newState;

        if (currrentState != null)
        {
            currrentState.InitState(this);
        }
    }

    private void Update()
    {
        if (currrentState != null)
        {
            currrentState.UpdateState(this);
        }
    }


}
