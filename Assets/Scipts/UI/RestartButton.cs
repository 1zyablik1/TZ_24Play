using UnityEngine;
using DG.Tweening;

public class RestartButton : MonoBehaviour
{
    private Sequence delaySequence;
    private float timeFadeDelay = 0.5f; // same as fadeTime 

    public void ResetLevel()
    {
        Events.OnRestartButtonClick?.Invoke();

        delaySequence = DOTween.Sequence();

        delaySequence.SetDelay(timeFadeDelay);
        delaySequence.AppendCallback(ChangeState);
    }

    private void ChangeState()
    {
        delaySequence.Kill();
        GlobalStateMachine.SetState<Menu>();
    }
}
