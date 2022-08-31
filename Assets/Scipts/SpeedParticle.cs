using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticle : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    private void OnEnable()
    {
        Subscribe();
        particle.SetActive(false);
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalGameStateExit += GlobalGameStateExit;
    }

    private void Unsubscribe()
    {
        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalGameStateExit -= GlobalGameStateExit;
    }

    private void GlobalGameStateEnter()
    {
        particle.SetActive(true);
    }

    private void GlobalGameStateExit()
    {
        particle.SetActive(false);
    }
}
