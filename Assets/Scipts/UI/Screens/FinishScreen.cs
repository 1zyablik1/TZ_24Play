public class FinishScreen : BaseScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        Events.OnGlobalFinishStateEnter += GlobalFinishStateEnter;
        Events.OnGlobalFinishStateExit += GlobalFinishStateExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        Events.OnGlobalFinishStateEnter -= GlobalFinishStateEnter;
        Events.OnGlobalFinishStateExit -= GlobalFinishStateExit;
    }

    protected void GlobalFinishStateEnter()
    {
        Enable();
    }

    protected void GlobalFinishStateExit()
    {
        Disable();
    }
}
