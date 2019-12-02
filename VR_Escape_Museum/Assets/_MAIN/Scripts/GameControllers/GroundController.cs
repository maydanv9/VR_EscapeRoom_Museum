using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform inspectingRoomPosition;

    private Vector3 currentPosition;
    private Vector3 currentRotation;

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
        currentPosition = player.position;
        currentRotation = camera.localEulerAngles;
        player = inspectingRoomPosition;
    }

    public void TeleportPlayerToGame()
    {

    }
}
