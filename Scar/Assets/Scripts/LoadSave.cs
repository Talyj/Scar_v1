﻿using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        if (File.Exists(destination))
        {
            panel.SetActive(true);   
        }
    }

    public void Load()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        if (File.Exists(destination))
        {
            string saveString = File.ReadAllText(destination);
            DataToSave data = JsonUtility.FromJson<DataToSave>(saveString);
            
            GameInfo.rangedDamage = data.rangeDamage;
            GameInfo.closedDamage = data.closeDamage;
            GameInfo.maxHealthPlayer = data.maxHealthPlayer;
            GunController.timeBetweenShots = data.shootDelay;
            GameInfo.levelBoss = data.levelBoss;

            if (data.levelBoss == 0)
            {
                SceneManager.LoadScene("Village"); 
            }
            else if (data.levelBoss == 1)
            {
                SceneManager.LoadScene("Village2");
            }
            else if (data.levelBoss == 2)
            {
                SceneManager.LoadScene("Village3");
            }
            else if (data.levelBoss == 3)
            {
                SceneManager.LoadScene("Village4");
            }
            else if (data.levelBoss == 4)
            {
                SceneManager.LoadScene("Village");
            }
        }
    }


}