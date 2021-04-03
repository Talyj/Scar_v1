using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    public string scene;
    public GameObject panel;
    private bool active;
    public GameObject panel2;
    public void Reload()
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
        if (choice == 0)
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
        else if (choice == 1)
        {
            if (active)
            {
                panel2.SetActive(false);
                active = false;
            }
            else
            {
                panel2.SetActive(true);
                active = true;
            }
        }
        
    }
    
}
