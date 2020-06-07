using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RiddleSpawner : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private List<Transform> riddleTransforms;
    [SerializeField] private List<GameObject> paintingRiddles; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> statueRiddles; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> chestRiddle; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> cabinetRiddle; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<BinRiddle> bins; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private MachineController machine; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private Transform riddlesParent;
    [SerializeField] private TMP_Text riddleKey;
    [SerializeField] private GameObject notePrefab;
    private int riddlesNumber;
    [SerializeField] private int[] keys;
    int i;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
        GenerateRiddles();
    }

    public void GenerateRiddles()
    {
        i = 1;
        keys = new int[5];
        //GENERATE PAINTING
        var randomNumber = Random.Range(0, paintingRiddles.Count);
        var randomRiddleNumber = Random.Range(0, riddleTransforms.Count);
        var riddle = Instantiate(paintingRiddles[randomNumber], riddlesParent);
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
        //GENERATE STATUE
        randomNumber = Random.Range(0, statueRiddles.Count);
        randomRiddleNumber = Random.Range(0, riddleTransforms.Count);
        riddle = Instantiate(statueRiddles[randomNumber], riddlesParent);
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
        //GENERATE CABINET
        randomNumber = Random.Range(0, cabinetRiddle.Count);
        randomRiddleNumber = Random.Range(0, riddleTransforms.Count);
        riddle = Instantiate(cabinetRiddle[randomNumber], riddlesParent);
        BaseRiddle key = riddle.GetComponent<BaseRiddle>();
        GameObject note = Instantiate(notePrefab);
        BaseNote baseNote = note.GetComponent<BaseNote>();
        key.SetBaseNote(GenerateKey(), baseNote, i);
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
        //GENERATE CHEST
        randomNumber = Random.Range(0, chestRiddle.Count);
        randomRiddleNumber = Random.Range(0, riddleTransforms.Count);
        riddle = Instantiate(chestRiddle[randomNumber], riddlesParent);
        key = riddle.GetComponentInChildren<BaseRiddle>();
        note = Instantiate(notePrefab);
        baseNote = note.GetComponent<BaseNote>();
        key.SetBaseNote(GenerateKey(), baseNote, i);
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
        //BINS
        randomNumber = Random.Range(0, bins.Count);
        BinRiddle binRiddle = bins[randomNumber];
        key = binRiddle.GetComponent<BaseRiddle>();
        note = Instantiate(notePrefab);
        baseNote = note.GetComponent<BaseNote>();
        key.SetBaseNote(GenerateKey(), baseNote, i);
        //MACHINE
        key = machine.GetComponent<BaseRiddle>();
        note = Instantiate(notePrefab);
        baseNote = note.GetComponent<BaseNote>();
        key.SetBaseNote(GenerateKey(), baseNote, i);

        Debug.Log("KeyCode is: " + riddleKey.text);

        SetKey();
    }

    private void GenerateNote(GameObject riddle)
    {
        BaseRiddle key = riddle.GetComponent<BaseRiddle>();
        GameObject note = Instantiate(notePrefab);
        BaseNote baseNote = note.GetComponent<BaseNote>();
        key.SetBaseNote(GenerateKey(), baseNote, i);
    }

    private void SetKey()
    {
        gameController.PinPadController.SetCode(riddleKey.text);
    }

    private int GenerateKey()
    {
        int key = Random.Range(1, 9);
        riddleKey.text += key.ToString();
        keys[i] = key;
        i++;
        return key;
    }
}
