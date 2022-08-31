using UnityEngine;
using DG.Tweening;

public class ParticleEffectCollected : MonoBehaviour
{
    private Sequence delaySequence;

    private void OnEnable()
    {
        delaySequence = DOTween.Sequence();

        delaySequence.SetDelay(0.5f);
        delaySequence.AppendCallback(Disable);
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
