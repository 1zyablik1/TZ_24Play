using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform cameraTransfrom;
    [SerializeField] Transform endPlatfromPoint;
    private float cameraOffset = 5;
    public List<Transform> spawnCollectableCube;
    [Header("containers")]
    public Transform deadlyCubeZone;
    public Transform collectableCubeZone;

    private void Start()
    {
        cameraTransfrom = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (endPlatfromPoint.position.z < cameraTransfrom.position.z - cameraOffset)
        {
            DisablePlatform();
        }
    }

    private void DisablePlatform()
    {
        DisableChild(collectableCubeZone);
        DisableChild(deadlyCubeZone);

        this.gameObject.SetActive(false);
        Events.OnPlatfromDelete?.Invoke();
    }

    private void DisableChild(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }

}
