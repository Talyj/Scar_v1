using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public void DoExitGame() {
        Application.Quit();
    }

    public void LoadScene(string level) {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void LoadOption() {
        Debug.Log("Options!");
    }
}
 