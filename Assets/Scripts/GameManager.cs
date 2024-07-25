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
    [SerializeField] private Slider playerHealthSlider;
    private float playerHealth;
    public float PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; UpdatePlayerHealth(); }
    }
    private float enemyHealth;
    public float EnemyHealth
    {
        get { return enemyHealth; }
        set { enemyHealth = value; UpdatePlayerHealth(); }
    }

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

    void Start()
    {
        PlayerHealth = 200;
        EnemyHealth = 200;
        UpdatePlayerHealth();
    }
    public void UpdatePlayerHealth()
    {
        if (playerHealthSlider != null)
        {
            float healthNormalized = playerHealth / (enemyHealth + playerHealth);
            playerHealthSlider.value = healthNormalized;
        }
    }
}
