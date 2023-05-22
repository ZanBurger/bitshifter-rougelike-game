using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene Instance;

    private string nextScene;
    private string previousScene;

    private void Awake() {
        
        if (Instance == null){
            Instance = this;
        } 
        else if (Instance != this){
            Destroy(gameObject);
        }
    }

    void Start() {
        // Gets the current scene name
       Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "demoLevel"){
            nextScene = "Hall1";
            previousScene = null;
        }
        else if (scene.name == "hall1"){
            nextScene = "BossRoom1";
            previousScene = "demoLevel";
        }
        else if (scene.name == "level2start"){
            nextScene = "level2hall";
            previousScene = null;
        }
        else if (scene.name == "level2hall"){
            nextScene = "level2boss";
            previousScene = null;
        }
        else if (scene.name == "level3start"){
            nextScene = "level3hall";
            previousScene = null;
        }
        else if (scene.name == "level3hall"){
            nextScene = "level3boss";
            previousScene = null;
        }
    }

    public void moveToNextScene(){
        SceneManager.LoadScene(nextScene);
    }

    public void moveToPreviousScene(){
        SceneManager.LoadScene(previousScene);
    }
}
