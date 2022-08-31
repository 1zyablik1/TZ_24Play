public class Menu :IGlobalState
{
    public void Enter()
    {
        Events.OnGlobalMenuStateEnter?.Invoke();
    }

    public void Exit()
    {
        Events.OnGlobalMenuStateExit?.Invoke();
    }

    public void Update()
    {
    }
}
