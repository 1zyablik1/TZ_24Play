using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public static GameObject staticPlayer;

    private void OnEnable()
    {
        InitPlayer();
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnGameReset += GameReset;
    }

    private void Unsubscribe()
    {
        Events.OnGameReset -= GameReset;
    }

    private void InitPlayer()
    {
        player = Instantiate(player, Vector3.zero, Quaternion.identity);
        staticPlayer = player;
    }

    public static Transform GetPlayerTransform()
    {
        return staticPlayer.transform;
    }

    public static GameObject GetPlayerGameObj()
    {
        return staticPlayer;
    }

    public static Player GetPlayer()
    {
        return staticPlayer.GetComponent<Player>();
    }

    private void GameReset()
    {
        player.transform.position = Vector3.zero;
    }
}
