using UnityEngine;
using DG.Tweening;

public class TextEffectCollected : MonoBehaviour
{
    private Sequence delaySequence;

    public void StartAnimation()
    {
        delaySequence = DOTween.Sequence();

        float newYPos = this.transform.position.y + 2f;

        delaySequence.Append(this.transform.DOMoveY(newYPos, 1f));
        delaySequence.AppendCallback(Disable);
    }

    private void Disable()
    {
        this.DOKill();
        this.gameObject.SetActive(false);
    }
}
