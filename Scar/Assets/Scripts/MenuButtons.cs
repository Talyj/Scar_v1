using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string scene;

    public void DoExitGame() {
        Application.Quit();
    }

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void LoadOption() {
        Debug.Log("Options!");
    }
}
 