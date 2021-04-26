﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LymuleHealth : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    public float degatsBullet = GameInfo.rangedDamage;
    public float degatWeapon = GameInfo.closedDamage;

    private void Start()
    {
        BossBehaviour.isAlive = 1;
        if (GameObject.FindGameObjectWithTag("Attaque"))
        {
            degatsBullet = degatsBullet * 110 / 100;
        }

        //if (GameObject.FindGameObjectWithTag("Attaque2"))
        //{
        //degats = degats * 120 / 100;
        //}
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0 && BossBehaviour.isAlive == 1)
        {
            BossBehaviour.isAlive = 0;
            GameInfo.levelBoss = 1;
            SpawnEnemy.nbMonster -= 1;
            new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulBasic"))
        {
            currentHealth -= degatsBullet;
            PlayerController.numberDamagesDealt += degatsBullet;
            Destroy(collision.gameObject);
        }
    }
}