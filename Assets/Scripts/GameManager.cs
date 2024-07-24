using UnityEngine;

public enum GameModes
{
    Easy,
    Normal,
    Hardcore
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameModes currentMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
