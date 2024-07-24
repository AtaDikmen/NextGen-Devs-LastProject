using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameModes
{
    easy,
    medium,
    hard
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameModes currentState;

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
