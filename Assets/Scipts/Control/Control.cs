using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private IControlable controlType;

    private void Start()
    {
        SetNoInput();
    }
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalGameStateExit += GlobalGameStateExit;
    }

    private void Unsubscribe()
    {
        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalGameStateExit -= GlobalGameStateExit;
    }

    private void GlobalGameStateEnter()
    {
        SetRunInput();
    }

    private void GlobalGameStateExit()
    {
        SetNoInput();
    }

    private void SetNoInput()
    {
        controlType = new NoInput();
    }

    private void SetRunInput()
    {
        controlType = new RunInput();
    }

    private void Update()
    {
        controlType.ControlInput();
    }
}
