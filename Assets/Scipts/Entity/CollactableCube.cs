using UnityEngine; 

public class CollactableCube : Trigger
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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.GetComponent<Trigger>())
        {
            case DeadlyCube:
                this.transform.SetParent(other.GetComponentInParent<Platform>().collectableCubeZone);
                Events.OnCollectableCubeDead?.Invoke(this);
                break;
        }
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
