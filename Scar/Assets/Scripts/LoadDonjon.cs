using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDonjon : MonoBehaviour
{
    [SerializeField] private GameObject confirmation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(false);
        }
    }

    public void Confirme()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "Village":
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                break;
            case  "Village2":
                SceneManager.LoadScene("Donjon2", LoadSceneMode.Single);
                break;
            case "Village3":
                SceneManager.LoadScene("Donjon3", LoadSceneMode.Single);
                break;
            case "Village4":
                SceneManager.LoadScene("Donjon4", LoadSceneMode.Single);
                break;
        }
    }
}
