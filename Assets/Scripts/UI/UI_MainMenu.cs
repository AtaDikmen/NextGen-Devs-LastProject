using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject[] panels;


    void Start()
    {
        SwitchTo(panels[0]);
    }

    void Update()
    {
        
    }

    public void SwitchTo(GameObject _panel)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        _panel.SetActive(true);
    }

    public void LoadScene(string _difficulty)
    {
        if (Enum.TryParse(_difficulty, true, out GameModes gameMode))
        {
            GameManager.Instance.currentMode = gameMode;
            SceneManager.LoadScene(1);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
