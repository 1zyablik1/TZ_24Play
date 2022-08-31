using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static GameSettings settings;

    private string gameSettingsPath = "Settings/gameSettings";

    void Awake()
    {
        settings = Resources.Load<GameSettings>(gameSettingsPath);
    }
}
