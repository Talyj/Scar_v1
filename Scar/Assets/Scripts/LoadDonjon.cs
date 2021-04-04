using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDonjon : MonoBehaviour
{
    [SerializeField] private string donjon;
    [SerializeField] private GameObject confirmation;
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("out");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            confirmation.SetActive(true);
        }
    }

    public void Confirme()
    {
        SceneManager.LoadScene(donjon, LoadSceneMode.Single);
    }
}
