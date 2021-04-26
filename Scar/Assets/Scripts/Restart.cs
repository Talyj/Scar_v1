using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    public string scene;
    public string scene2;
    public GameObject panel;
    private bool active;
    public void Reload(int choice)
    {
        if(choice == 0)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        else if(choice == 1)
        {
            SceneManager.LoadScene(scene2, LoadSceneMode.Single);
        }
    }

    public void loadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Activate(int choice)
    {
        if (active)
        {
            panel.SetActive(false);
            active = false;
        }
        else
        {
            panel.SetActive(true);
            active = true;
        }
    }
}
