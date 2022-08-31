using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : BaseUI
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Image bgImage;
    [SerializeField] private TMP_Text textLose;
    [SerializeField] private TMP_Text textButton;

    private float timeElement = 1.5f;
    private float timeBG = 0.5f;

    private Sequence fadeSequence;

    private void Awake()
    {
        ResetPanel();
    }

    private void OnEnable()
    {
        AnimatePanel();
    }

    private void OnDisable()
    {
        ResetPanel();
    }

    private void AnimatePanel()
    {
        fadeSequence = DOTween.Sequence();

        fadeSequence.Append(buttonImage.DOFade(1, timeElement));
        fadeSequence.Insert(0, textButton.DOFade(1, timeElement));
        fadeSequence.Insert(0, textLose.DOFade(1, timeElement));
        fadeSequence.Insert(0, bgImage.DOFade(1, timeBG));
    }

    private void ResetPanel()
    {
        SetImageAlpa(bgImage, 0);
        SetImageAlpa(buttonImage, 0);
        textLose.alpha = 0;
        textButton.alpha = 0;
    }
}
