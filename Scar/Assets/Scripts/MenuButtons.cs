using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{   
    [SerializeField]private GameObject EditionMap;
    public string scene;

    public void DoExitGame() {
        Application.Quit();
    }

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void LoadEditionMap() {
        EditionMap.SetActive(true);
    }
}
 