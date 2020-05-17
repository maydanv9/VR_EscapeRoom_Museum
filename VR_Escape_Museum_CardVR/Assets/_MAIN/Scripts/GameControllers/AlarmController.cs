using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    private GameController gameController;
    private bool enabled = false;
    [SerializeField] private MeshRenderer alarmRenderer;
    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void OnAlarmEnabled()
    {
        if (enabled) return;
        enabled = true;
        StartCoroutine(AlarmCoroutine());
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
