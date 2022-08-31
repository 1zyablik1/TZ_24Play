using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private IMovableType currentMoveType;
    private IMovableType zeroMove;
    private IMovableType runMove;

    public Vector1 posX;
    [SerializeField] TrailRenderer trail;

    private void MoveStart()
    {
        posX = new Vector1();

        zeroMove = new ZeroMove();
        runMove = new RunMove(this.transform, posX);

        GameReset();
    }

    private void SetZeroMove()
    {
        currentMoveType = zeroMove;
        posX.x = 0;
    }

    private void SetRunMove()
    {
        currentMoveType = runMove;
    }

    private void MoveFixedUpdate()
    {
        currentMoveType.Move();
    }

    private void EnableTrail()
    {
        trail.emitting = true;
    }

    private void DisableTrail()
    {
        trail.emitting = false;
    }
}
