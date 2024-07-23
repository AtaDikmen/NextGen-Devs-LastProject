using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void QuitGame()
    {
        Application.Quit();
    }
}
