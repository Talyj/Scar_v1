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
        string destination = Application.persistentDataPath + "/game.json";
        DataToSave dataToSave = new DataToSave
        {
            shootDelay = GunController.timeBetweenShots,
            maxHealthPlayer = HealthPlayer.maxHealth,
            rangeDamage = GameInfo.rangedDamage,
            closeDamage = GameInfo.closedDamage,
            levelBoss = GameInfo.levelBoss,
            activeSkill = GameInfo.activeSkill,
            activeLevel = GameInfo.activeLevel,
            passiveSkill = GameInfo.passiveSkill,
            passiveLevel = GameInfo.passiveLevel
        };
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(destination, json);
    }
}
