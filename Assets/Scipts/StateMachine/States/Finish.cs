public class Finish : IGlobalState
{
    public void Enter()
    {
        Events.OnGlobalFinishStateEnter?.Invoke();
    }

    public void Exit()
    {
        Events.OnGlobalFinishStateExit?.Invoke();
        Events.GameReset();
    }

    public void Update()
    {
    }
}
