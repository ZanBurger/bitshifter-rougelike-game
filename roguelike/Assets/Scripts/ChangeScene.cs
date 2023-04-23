using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene Instance;

    public void moveToScene(){

        SceneManager.LoadScene("hall1");
    }
}
