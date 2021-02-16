using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    [SerializeField] private GameObject inventaire;
    private bool active;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (active)
            {
                active = false;
                inventaire.SetActive(false);
            }
            else
            {
                active = true;
                inventaire.SetActive(true);
            }
        }
    }
}
