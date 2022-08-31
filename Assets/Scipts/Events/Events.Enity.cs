using System;
using UnityEngine;
public partial class Events
{
    public static Action OnPlatfromDelete;
    public static Action<CollactableCube> OnCollectableCubeDead;
    public static Action OnObstacleCollision;
    public static Action OnCubeCollected;
}
