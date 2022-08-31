using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    [SerializeField] private Transform cubeHolder;
    private Trigger trigger;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.GetComponent<Trigger>())
        {
            case CollactableCube:
                Events.OnCubeCollected?.Invoke();

                AnimateJump();
                AddColactableCubeToStack(other.GetComponent<CollactableCube>());
                
                break;
            case ReAnimTrigger:
                ReAnimateStack();

                break;
            default:
                break;
        }
    }
}
