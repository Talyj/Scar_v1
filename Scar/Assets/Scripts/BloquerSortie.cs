using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquerSortie : MonoBehaviour
{
    [SerializeField] private GameObject porte;
    [SerializeField] private GameObject sortie;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(porte, sortie.transform.position, sortie.transform.rotation);
            Debug.Log("Porte");
        }
    }
}
