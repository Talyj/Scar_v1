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
            Save();
            Load();
        }
    }

    /*        SAUVEGARDE DES INFORMATIONS DU JOUEUR        */
    private void Save()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        DataToSave dataToSave = new DataToSave
        {
            shootDelay = GunController.timeBetweenShots,
            maxHealthPlayer = 200,
            rangeDamage = GameInfo.rangedDamage,
            closeDamage = GameInfo.closedDamage,
            levelBoss = PlayerController.levelBoss
        };
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(destination, json);
        Debug.Log("Saved !");
    }

    private void Load()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        if (File.Exists(destination))
        {
            string saveString = File.ReadAllText(destination);
            Debug.Log("File Loaded !");

            DataToSave data = JsonUtility.FromJson<DataToSave>(saveString);
            GameInfo.rangedDamage = data.rangeDamage;
            GameInfo.closedDamage = data.closeDamage;
        }
    }
}
