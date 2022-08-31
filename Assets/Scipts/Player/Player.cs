using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    void Awake()
    {
        AnimatorAwake();
        StackAwake();
    }

    void Start()
    {
        StackStart();
        MoveStart();
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Lose()
    {
        DisableTrail();
        EnableRagdoll();
        SetZeroMove();
        GlobalStateMachine.SetState<Finish>();
    }
}
