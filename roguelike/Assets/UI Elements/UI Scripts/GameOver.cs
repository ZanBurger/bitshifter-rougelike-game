using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject _player; 
    public GameObject gameOverUI;
    public GameObject healthBarUI;
    public GameObject bossBarUI;

    void Start()
    {
        Time.timeScale = 1f;
        var gameObjectP = GameObject.Find("Player");
        if (gameObjectP == null) return;
        _player = gameObjectP;
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null){
            Time.timeScale = 0f;
            healthBarUI.SetActive(false);

            if(bossBarUI != null)
            { 
                bossBarUI.SetActive(false);
            }
           
            gameOverUI.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
