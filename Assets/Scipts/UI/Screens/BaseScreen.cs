using UnityEngine;

public class BaseScreen : BaseUI
{
    public override void Init()
    {
        base.Init();

        Disable();
    }

    protected override void GameReset()
    {
        base.GameReset();

        Disable();
    }
}
