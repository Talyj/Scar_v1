using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string scene;
    public void Reload()
    {
        SceneManager.LoadScene(scene);
    }
}
