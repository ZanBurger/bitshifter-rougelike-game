using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerController.deathAmount = 0;
        PlayerController.unlockedTeleport = false;
        PlayerController.unlockedMultishot = false;
        PlayerController.unlockedBomb = false;
        PlayerController.unlockedRun = false;
    }
    
    public void ExitGame()
    {
        Debug.Log("Game closed.");
        Application.Quit();
    }


}
