using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int KillCount { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddKill()
    {
        KillCount++;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void StartGame()
    {
        KillCount = 0;
        SceneManager.LoadScene("PlayScreen");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("IntroScreen");
    }
}
