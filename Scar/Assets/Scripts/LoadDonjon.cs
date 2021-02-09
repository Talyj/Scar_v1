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
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(true);
        }
    }

    public void Confirme()
    {
        SceneManager.LoadScene(donjon);
    }
}
