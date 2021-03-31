﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class KorinhBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private HealthEnemy BossHealth;
    private Transform player;
    
    // Derniere Chance
    [SerializeField] private GameObject pat;
    [SerializeField] private GameObject put;
    private bool premiereChance = true;
    private bool derniereChance = true;
    public bool enervax = true;
    private HealthEnemy currentHealth;
    
    public static int isAlive = 1;
    
    //Cooldown attaque basique
    private float hitCounter; 
    private float timeBetweenHits;
    [SerializeField] private AttackZoneController bossBaseAttack;
    [SerializeField] private Transform[] hitPoints;
    [SerializeField] private Transform BasePoint;
    
    //Deplacement du boss pour la charge
    [SerializeField] private float defaultSpeedMonster;
    private float speed;

    //BigAss Attaque
    [SerializeField] private AttackZoneController bossLongAttack;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenHits = 5;
        speed = defaultSpeedMonster;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //firepoint = GameObject.FindGameObjectWithTag("boss").ge;
        StartCoroutine(BossBehaviour());
    }

    private void Update()
    {
        Deplacement();
    }

    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator BossBehaviour()
    {
        // Tant que le boss est en vie on le fait agir
        while(Boss != null)
        {
            Charge();
            hitCounter -= Time.deltaTime;
            if (hitCounter <= 0)
            {
                BasicAttack();
                BigAssAttackOfDoom();
                hitCounter = timeBetweenHits;
            }
            else
            {
                hitCounter = 0;
            }
            
            // Condition actions du boss 75% de vie = spawn petit groupe de monstre 
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.75 && premiereChance)
            {
                SpawnEnemy.Spawn(3, put);
                yield return new WaitForSeconds(2);
                SpawnEnemy.Spawn(5, pat);
                premiereChance = false;
                enervax = false;
            }
            // 25% de vie = spawn groupe de monstre medium réactive enervax
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.25 && derniereChance)
            {
                enervax = true;
                SpawnEnemy.Spawn(5, put);
                yield return new WaitForSeconds(2);
                SpawnEnemy.Spawn(8, pat);
                derniereChance = false;
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void BigAssAttackOfDoom()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 40 && dist >= 20)
        {
            int nbAttack = Random.Range(1, 3);
            if (nbAttack == 1)
            {
                foreach (var point in hitPoints)
                {
                    AttackZoneController newZone = Instantiate(bossLongAttack, point.position, point.rotation) as AttackZoneController;
                }   
            }
            else if (nbAttack == 2)
            {
                for (int i = 1; i <= 2; i++)
                {
                    AttackZoneController newZone = Instantiate(bossLongAttack, hitPoints[i].position, hitPoints[i].rotation) as AttackZoneController;
                }
            }
            else
            {
                AttackZoneController newZone = Instantiate(bossLongAttack, hitPoints[0].position, hitPoints[0].rotation) as AttackZoneController;
            }
        }
    }
    
    private void BasicAttack()
   {
       float dist = Vector3.Distance(gameObject.transform.position, player.position);
       if (dist <= 20)
       {
           AttackZoneController newZone =
           Instantiate(bossBaseAttack, BasePoint.position, BasePoint.rotation) as AttackZoneController;
       }
   }

    private void Charge()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist >= 45)
        {
            speed = 30;
        }
        if (dist <= 20)
        {
            speed = defaultSpeedMonster;
        }
    }

    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
        
        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
}