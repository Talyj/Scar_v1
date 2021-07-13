using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameObject : MonoBehaviour
{
    [SerializeField]private GameObject EditionMapMenu;
    public Animator options;
    public AudioSource audio;

    public void FermerMenu() {
        options.Play("Base Layer.Retour");
        audio.Play(0);
        Invoke("FermerMenu2", 1.5f);
    }

    public void FermerMenu2() {
        EditionMapMenu.SetActive(false);
    }

    public void OuvrirMenu() {
        EditionMapMenu.SetActive(true);
    }
}
