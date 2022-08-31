using UnityEngine;

[CreateAssetMenu(fileName = "settings", menuName = "Settings/GenerateSets", order = 1)]
public class GeneratePatterns : ScriptableObject
{
    public int[] sets = new int[5];
}
