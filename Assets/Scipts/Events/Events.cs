using System;

public partial class Events
{
    public static Action OnGameReset;

    public static void GameReset()
    {
        OnGameReset?.Invoke();
    }
}
