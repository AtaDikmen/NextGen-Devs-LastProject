using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] private GameObject UICanvas;
    private Slider playerHealthSlider;
    private TextMeshProUGUI playerGoldText;
    private int currentPlayerGold;
    public int CurrentPlayerGold
    {
        get { return currentPlayerGold; }
        set { currentPlayerGold = value; UpdatePlayerGold(); }
    }
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
            playerHealthSlider = UICanvas.transform.GetChild(0).GetComponent<Slider>();
            playerGoldText = UICanvas.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerHealth = 200;
        enemyHealth = 200;
        CurrentPlayerGold = 0;
        UpdatePlayerHealth();
        StartCoroutine(GainGoldOverTime(1));

    }
    private IEnumerator GainGoldOverTime(int second)
    {
        while (true)
        {
            yield return new WaitForSeconds(second);
            CurrentPlayerGold += 1;
        }
    }
    public void UpdatePlayerHealth()
    {
        if (playerHealthSlider != null)
        {
            float healthNormalized = playerHealth / (enemyHealth + playerHealth);
            playerHealthSlider.value = healthNormalized;
        }

        CheckEndGame();
    }

    public void UpdatePlayerGold()
    {
        playerGoldText.text = currentPlayerGold.ToString();
    }

    private void CheckEndGame()
    {
        if (playerHealth <= 0)
        {
            GameManager.Instance.hasWon = false;
            SceneManager.LoadScene(2);
        }
        else if (enemyHealth <= 0)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + currentPlayerGold);
            GameManager.Instance.hasWon = true;
            SceneManager.LoadScene(2);
        }
    }
}
