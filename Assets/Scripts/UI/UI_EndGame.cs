using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI endGameHeader;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;
    void Start()
    {
        if (GameManager.Instance.hasWon)
        {
            endGameHeader.text = "Victory!";
            winText.gameObject.SetActive(true);
        }
        else
        {
            endGameHeader.text = "Defeated!";
            loseText.gameObject.SetActive(true);
        }
    }

    public void ContinueToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
