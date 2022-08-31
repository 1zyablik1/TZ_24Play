using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    private Vector3 targetPositon;

    private float shakeTime = 0.2f;

    private void Start()
    {
        target = PlayerManager.GetPlayerTransform();
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
        Events.OnObstacleCollision += ObstacleCollision;
    }

    private void Unsubscribe()
    {
        Events.OnObstacleCollision -= ObstacleCollision;
    }

    private void ObstacleCollision()
    {
        Camera.main.transform.DOShakePosition(shakeTime, 0.5f);
    }


    private void LateUpdate()
    {
        targetPositon = new Vector3(0, target.position.y, target.position.z);
        this.transform.position = targetPositon;
    }
}
