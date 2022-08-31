using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyZone : MonoBehaviour
{
    public Transform deadlyCubeZone;
    public Transform collectableCubeZone;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.GetComponent<CollactableCube>())
        {
            case CollactableCube:
                Events.OnObstacleCollision?.Invoke();

                DisableChildTriggers(collectableCubeZone);
                DisableChildTriggers(deadlyCubeZone);
                break;
            default:

                break;
        }
    }
    private void DisableChildTriggers(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.GetComponent<Collider>().enabled = false;
        }
    }
}
