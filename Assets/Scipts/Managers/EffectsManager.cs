using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private Pool collectedEffectPool;
    private Pool collectedTextPool;

    [SerializeField] GameObject collectedEffectContainer;
    [SerializeField] GameObject collectedEffect;

    [SerializeField] GameObject collectedTextContainer;
    [SerializeField] GameObject collectedText;

    private void Awake()
    {
        collectedEffectPool = new Pool(collectedEffect, collectedEffectContainer);
        collectedTextPool = new Pool(collectedText, collectedTextContainer);
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnCubeCollected += CubeCollected;
    }

    private void Unsubscribe()
    {
        Events.OnCubeCollected -= CubeCollected;
    }

    private void CubeCollected()
    {
        var player = PlayerManager.GetPlayer();
        var playerPosition = player.transform.position;

        var effectPosition = new Vector3(playerPosition.x, 1f, playerPosition.z);
        
        var textPosition = new Vector3(playerPosition.x, player.GetHight() + 2, playerPosition.z);

        collectedEffectPool.GetFreeElement(effectPosition);
        var effect = collectedTextPool.GetFreeElement(textPosition);

        effect.GetComponent<TextEffectCollected>().StartAnimation();
    }
}
