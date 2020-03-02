using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> riddleTransforms;
    [SerializeField] private List<GameObject> riddles; //TO DO: CHANGE TO BASE INTERACTABLE AFTER FIXING PAINTING
    [SerializeField] private Transform riddlesParent;
    private int riddlesNumber;


    public void GenerateRiddles()
    {
        for(int i = 0; i < riddleTransforms.Count; i++)
        {
            var randomNumber = Random.Range(0, riddles.Count);
            var riddle = Instantiate(riddles[randomNumber], riddlesParent);
            riddle.transform.position = riddleTransforms[i].position;
            riddle.transform.rotation = riddleTransforms[i].rotation;
        }
    }
}
