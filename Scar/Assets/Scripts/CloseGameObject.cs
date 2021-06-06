using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameObject : MonoBehaviour
{
    [SerializeField]private GameObject EditionMapMenu;

    public void FermerMenu() {
        EditionMapMenu.SetActive(false);
    }

    public void OuvrirMenu() {
        EditionMapMenu.SetActive(true);
    }
}
