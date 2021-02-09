using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string scene;
    public GameObject pause;
    public void Reload()
    {
        SceneManager.LoadScene(scene);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
    }

}
