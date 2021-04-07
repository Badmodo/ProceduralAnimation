using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    bool gameIsOver;

    private void Start()
    {
        EnemyAI.OnGuardHasSpottedPlayer += ShowGameLoseUI;
    }

    private void Update()
    {
        if(gameIsOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ShowGameLoseUI()
    {
        OnGameOver(gameLoseUI);
    }
    
    void ShowGameWinUI()
    {
        OnGameOver(gameWinUI);
    }

    void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        gameIsOver = true;
        EnemyAI.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
    }
}
