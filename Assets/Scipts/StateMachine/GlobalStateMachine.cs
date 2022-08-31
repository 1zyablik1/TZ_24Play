using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlobalStateMachine : MonoBehaviour
{
    private static List<IGlobalState> states;
    private static IGlobalState currentState;

    private void Awake()
    {
        states = new List<IGlobalState>()
        {
            new Menu(),
            new Game(),
            new Finish()
        };
    }

    private void Start()
    {
        SetState<Menu>();
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
        Events.OnGameReset += GameReset;
    }

    private void Unsubscribe()
    {
        Events.OnGameReset -= GameReset;
    }

    private void GameReset()
    {
    }

    public static bool IsFinishState()
    {
        if(currentState is Finish)
        {
            return true;
        }
        return false;
    }

    public static void SetState<T>() where T : IGlobalState
    {
        IGlobalState newState = states.FirstOrDefault(s => s is T);

        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    private void Update()
    {
        currentState?.Update();
    }
}
