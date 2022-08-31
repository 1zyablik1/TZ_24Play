using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonCLicked()
    {
        GlobalStateMachine.SetState<Game>();
    }
}
