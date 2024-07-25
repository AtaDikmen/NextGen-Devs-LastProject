using UnityEngine;
using UnityEngine.UI;

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
    public bool hasWon;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            hasWon = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
