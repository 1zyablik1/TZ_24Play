
public class GameScreen : BaseScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalGameStateExit += GlobalGameStateExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalGameStateExit -= GlobalGameStateExit;
    }

    protected void GlobalGameStateEnter()
    {
        Enable();
    }

    protected void GlobalGameStateExit()
    {
        Disable();
    }
}
