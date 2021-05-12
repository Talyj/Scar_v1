using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDecor : MonoBehaviour
{
    public GameObject marecage;
    

    void Start()
    {
        Scene scene = EditorSceneManager.GetActiveScene();
        if(scene.name == "Main")
        {
            marecage.SetActive(true);
        }
        else
        {
            marecage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
