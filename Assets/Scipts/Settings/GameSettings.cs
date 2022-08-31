using UnityEngine;

[CreateAssetMenu(fileName = "settings", menuName = "Settings/Game settings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int roadWidth;

    public float speed;
    public float sideSpeed;
    public float cubeCollectingSpeed;
}
