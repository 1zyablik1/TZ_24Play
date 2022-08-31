using DG.Tweening;
using UnityEngine.UI;

public class FadePanel : BaseUI
{
    private Sequence fadeSequence;
    private Image fadeImage;
    private float fadeTime = 0.5f; //same timeFadeDelay

    protected void Awake()
    {
        fadeImage = this.GetComponent<Image>();
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        Events.OnGlobalMenuStateEnter += GlobalMenuStateEnter;
        Events.OnRestartButtonClick += RestartButtonClicked;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        Events.OnGlobalMenuStateEnter -= GlobalMenuStateEnter;
        Events.OnRestartButtonClick -= RestartButtonClicked;
    }

    private void GlobalMenuStateEnter()
    {
        AnimateFade(1, 0);
    }

    private void RestartButtonClicked()
    {
        AnimateFade(0, 1);
    }

    private void AnimateFade(int startFade, int endFade)
    {
        ChangeRaycastableTarget(fadeImage, endFade);
        SetImageAlpa(fadeImage, startFade);

        fadeSequence?.Kill();
        fadeSequence = DOTween.Sequence();

        fadeSequence.Append(fadeImage.DOFade(endFade, fadeTime));
    }
}
