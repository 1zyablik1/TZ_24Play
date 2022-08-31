public class MenuScreen : BaseScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        Events.OnGlobalMenuStateEnter += GlobalMenuStateEnter;
        Events.OnGlobalMenuStateExit += GlobalMenuStateExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        Events.OnGlobalMenuStateEnter -= GlobalMenuStateEnter;
        Events.OnGlobalMenuStateExit -= GlobalMenuStateExit;
    }

    protected void GlobalMenuStateEnter()
    {
        Enable();
    }

    protected void GlobalMenuStateExit()
    {
        Disable();
    }
}
