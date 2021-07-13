using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{   
    [SerializeField]private GameObject EditionMap;
    public string scene;
    public Animator anim;
    public Animator options;
    public AudioSource audio;

    public void DoExitGame() {
        anim.SetBool("Fade", true);
        Invoke("DoExitGame2", 1.0f);
    }

    public void DoExitGame2() {
        Application.Quit();
    }

    public void LoadScene() {
        anim.SetBool("Fade", true);
        Invoke("LoadScene2", 1.0f);
    }

    public void LoadScene2() {
        SceneManager.LoadScene(scene);
    }

    public void LoadEditionMap() {
        EditionMap.SetActive(true);
        options.Play("Base Layer.VenantDuHaut");
        audio.Play(0);
    }

    public void ActiveMenu() {
        EditionMap.SetActive(true);
    }
}
 