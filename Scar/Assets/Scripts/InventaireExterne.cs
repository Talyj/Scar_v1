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
        
        //DataToSave loadedData = JsonUtility.FromJson<DataToSave>(json);
        //Debug.Log(loadedData.shootDelay);
    }

    private void Load()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        if (File.Exists(destination))
        {
            string saveString = File.ReadAllText(destination);
            Debug.Log("File Loaded !");

            DataToSave data = JsonUtility.FromJson<DataToSave>(saveString);
            Debug.Log(data.rangeDamage);
        }
    }
    
    private class DataToSave
    {
        public float shootDelay;
        public float maxHealthPlayer;
        public float rangeDamage;
        public float closeDamage;
        public int levelBoss;
    }
    
    /*private void SaveTest()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        shootDelay = GunController.timeBetweenShots;
        maxHealthPlayer = 200;
        rangeDamage = GameInfo.rangedDamage;
        closeDamage = GameInfo.closedDamage;
        levelBoss = PlayerController.levelBoss;
        
        string[] data = new string[]
        {
            "shoot_delay=" + shootDelay,
            "max_health=" + maxHealthPlayer,
            "ranged_damage=" + rangeDamage,
            "closed_damage=" + closeDamage,
            "level_boss=" + levelBoss
        };

        string saveString = string.Join(SAVE_SEPARATOR, data);
        File.WriteAllText(destination, saveString);
        
        Debug.Log("Saved !");
    }*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
