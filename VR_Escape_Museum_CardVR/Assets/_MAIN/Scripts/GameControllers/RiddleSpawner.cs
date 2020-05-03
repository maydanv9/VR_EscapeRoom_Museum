using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> riddleTransforms;
    [SerializeField] private List<GameObject> paintingRiddles; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> statueRiddles; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> chestRiddle; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private List<GameObject> cabinetRiddle; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private Transform riddlesParent;
    private int riddlesNumber;


    public void GenerateRiddles()
    {
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
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
        //GENERATE CHEST
        randomNumber = Random.Range(0, chestRiddle.Count);
        randomRiddleNumber = Random.Range(0, riddleTransforms.Count);
        riddle = Instantiate(chestRiddle[randomNumber], riddlesParent);
        riddle.transform.position = riddleTransforms[randomRiddleNumber].position;
        riddle.transform.rotation = riddleTransforms[randomRiddleNumber].rotation;
        riddleTransforms.RemoveAt(randomRiddleNumber);
    }
}
