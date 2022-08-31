using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMove : IMovableType
{
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector1 posX;

    private Transform playerTransform;

    public RunMove(Transform transform, Vector1 posX)
    {
        playerTransform = transform;
        this.posX = posX;
    }

    private void MoveOnX()
    {
        Vector3 targetPos = new Vector3(posX.x, playerTransform.position.y, playerTransform.position.z);
        playerTransform.position = Vector3.MoveTowards
            (playerTransform.position, targetPos, SettingsManager.settings.sideSpeed * Time.deltaTime);
    }

    public void Move()
    {
        moveDirection = direction * SettingsManager.settings.speed * Time.deltaTime;

        playerTransform.position = playerTransform.position + moveDirection;
        MoveOnX();
    }
}
