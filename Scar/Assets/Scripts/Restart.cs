using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{

    public string scene;
    
    [SerializeField]
    private GameObject panel;
    private bool active;

    public void Reload()
    {
        SceneManager.LoadScene(scene);
    }

   
    


    public void onClick()
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
