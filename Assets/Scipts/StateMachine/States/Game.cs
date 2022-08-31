public class Game : IGlobalState
{
    public void Enter()
    {
        Events.OnGlobalGameStateEnter?.Invoke();
    }

    public void Exit()
    {
        Events.OnGlobalGameStateExit?.Invoke();
    }

    public void Update()
    {
    }
}
