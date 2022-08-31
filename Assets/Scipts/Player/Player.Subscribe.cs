using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Subscribe()
    {
        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalGameStateExit += GlobalGameStateExit;
        Events.OnCollectableCubeDead += CollectableCubeDead;

        Events.OnGameReset += GameReset;
    }

    private void Unsubscribe()
    {
        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalGameStateExit -= GlobalGameStateExit;
        Events.OnCollectableCubeDead -= CollectableCubeDead;

        Events.OnGameReset -= GameReset;
    }

    private void GlobalGameStateEnter()
    {
        SetRunMove();
    }

    private void GlobalGameStateExit()
    {
        SetZeroMove();
    }

    private void CollectableCubeDead(CollactableCube cube)
    {
        collactableCubes.Remove(cube);

        if(collactableCubes.Count == 0 && !GlobalStateMachine.IsFinishState())
        {
            Lose();
        }
    }

    private void GameReset()
    {
        SetZeroMove();
        ResetAnimator();
        SetDefaultStack();
        EnableTrail();
    }
}
