using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquerSortie : MonoBehaviour
{
    [SerializeField] private GameObject porte;
    [SerializeField] private GameObject[] sorties;
    [SerializeField] private GameObject entree;
    private Boolean mustBlockExit;
    private Boolean mustBlockEntry;

    private void Start()
    {
        mustBlockExit = true;
        mustBlockEntry = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mustBlockExit)
            {
                foreach (var spawn in sorties)
                {
                    Instantiate(porte, spawn.transform.position, spawn.transform.rotation);
                }
                mustBlockExit = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mustBlockEntry)
            {
                Instantiate(porte, entree.transform.position, entree.transform.rotation);
                mustBlockEntry = false;
            }
        }
    }
}
