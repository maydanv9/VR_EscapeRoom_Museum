using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private GameController gameController;
    private float duration;
    private float startTime;
    private float endTime;
    public void Init(GameController gameController)
    {
        this.gameController = gameController;
    }

    public void StartTimer()
    {
        startTime = Time.time;
    }   

    public void EndTimer()
    {
        endTime = Time.time;
    }

    public float GetTime()
    {
        return startTime - endTime;
    }
}
