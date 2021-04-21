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
        }
    }

    /*        SAUVEGARDE DES INFORMATIONS DU JOUEUR        */
    private void Save()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        DataToSave dataToSave = new DataToSave
        {
            shootDelay = GameInfo.shootDelay,
            maxHealthPlayer = GameInfo.maxHealthPlayer,
            rangeDamage = GameInfo.rangedDamage,
            closeDamage = GameInfo.closedDamage,
            levelBoss = GameInfo.levelBoss
        };
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(destination, json);
        Debug.Log("Saved !");
    }
}
