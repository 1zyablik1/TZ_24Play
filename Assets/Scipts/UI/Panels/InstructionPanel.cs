using DG.Tweening;
using UnityEngine;

public class InstructionPanel : BasePanel
{
    [SerializeField] private RectTransform pointTransform;

    private Sequence movingSequence;

    private float animTime = 2.5f;
    private float endPosX = 350;
    private float posY = -45;

    protected void OnEnable()
    {
        AnimateInstuction();
    }

    protected void OnDisable()
    {
        StopInstruction();
    }

    private void AnimateInstuction()
    {
        movingSequence = DOTween.Sequence();

        movingSequence.Append(pointTransform.DOAnchorPos(new Vector2(-1 * endPosX, posY), animTime)).SetEase(Ease.Linear);
        movingSequence.Append(pointTransform.DOAnchorPos(new Vector2(endPosX, posY), animTime)).SetEase(Ease.Linear);

        movingSequence.SetLoops(-1);
    }

    private void StopInstruction()
    {
        movingSequence?.Kill();
        pointTransform.anchoredPosition = new Vector2(endPosX, posY);
    }
}
