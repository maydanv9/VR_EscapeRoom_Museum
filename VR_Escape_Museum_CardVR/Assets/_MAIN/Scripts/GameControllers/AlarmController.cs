using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    private GameController gameController;
    private bool enabled = false;
    [SerializeField] private MeshRenderer alarmRenderer;
    [SerializeField] protected AudioSource alarmSound;


    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void OnAlarmEnabled()
    {
        gameController.TimeController.StartTimer();
        if (enabled) return;
        enabled = true;
        alarmSound.Play();
        StartCoroutine(AlarmCoroutine());
    }

    public void CancelAlarm()
    {
        enabled = false;
    }

    private IEnumerator AlarmCoroutine()
    {
        while (enabled)
        {
            alarmRenderer.sharedMaterial.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            alarmRenderer.sharedMaterial.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
