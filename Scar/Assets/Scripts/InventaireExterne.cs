using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventaireExterne : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveProgression();
        }
    }

    private void SaveProgression()
    {
        string destination = Application.persistentDataPath + "/game.dat";

        /*if (File.Exists(destination))
        {
            Debug.Log("yep");
            return;
        }*/

        var sr = File.CreateText(destination);
        sr.WriteLine(GunController.timeBetweenShots);
        Debug.Log("saved");
        sr.Close();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
