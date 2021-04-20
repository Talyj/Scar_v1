using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public int nbBossBeaten;
    public HealthPlayer healthPlayer;
    public float rangeDamage;
    public float closeDamage;
    public int score;

   private void Start()
    {
        score = PlayerController.score;
        healthPlayer = HealthPlayer.FindObjectOfType<HealthPlayer>();
        rangeDamage = HealthEnemy.degatsBullet;
        closeDamage = HealthEnemy.degatWeapon;
        if (PlayerController.flueDead)
        {
            nbBossBeaten = 4;
        }
        else if (PlayerController.bobbDead)
        {
            nbBossBeaten = 3;
        }
        else if (PlayerController.korinhDead)
        {
            nbBossBeaten = 2;
        }
        else if (PlayerController.lymuleDead)
        {
            nbBossBeaten = 1;
        }
    }
}
