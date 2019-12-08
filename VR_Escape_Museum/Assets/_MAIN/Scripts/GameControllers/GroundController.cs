using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform inspectingRoomPosition;

    private Vector3 savedPosition;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void TeleportPlayer(Vector3 _position)
    {
        player.position = new Vector3(_position.x, player.position.y, _position.z);
    }

    public void TeleportPlayerToInspectingRoom()
    {
        gameController.SceneReferences.ExamineRoom.SetActive(true);
        gameController.SceneReferences.GameTerrain.SetActive(false);
        gameController.UIController.ExamineView.ShowView();

        savedPosition = player.position;
        player.position = inspectingRoomPosition.position;
    }

    public void TeleportPlayerToGame()
    {
        gameController.SceneReferences.ExamineRoom.SetActive(false);
        gameController.SceneReferences.GameTerrain.SetActive(true);
        gameController.UIController.ExamineView.HideView();

        player.position = savedPosition;
    }
}
