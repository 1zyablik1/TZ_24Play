using UnityEngine;

public class DeadlyCube : Trigger
{
    private Collider cubeCollider;

    private void Awake()
    {
        cubeCollider = this.GetComponent<Collider>();
        EnableCollider();
    }

    private void OnEnable()
    {
        EnableCollider();
    }

    public void EnableCollider()
    {
        cubeCollider.enabled = true;
    }

    public void DisableCollider()
    {
        cubeCollider.enabled = false;
    }
}
