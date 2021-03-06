﻿using System.Collections;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject big;
    public  GameObject small;
    public  GameObject boss;
    public GameObject spawnMonster;
    private static float xPos;
    private static float zPos;

    private int numBig;
    private  int numSmall;

    [SerializeField] private int numMonsters;
    private int monstreRecup;
    public int numBoss;
    public int timeBetweenGroups;
    
    public static int nbMonster;

    private GameObject door;
    private GameObject spawnPoint;

    private void Awake()
    {
        monstreRecup = numMonsters;
    }

    void Start()
    {
        StartCoroutine(MonstersGrrr(monstreRecup));
    }

    private void Update()
    {
        spawnPoint = spawnMonster;
        
        xPos = Random.Range(spawnPoint.transform.position.x - 15, spawnPoint.transform.position.x) + 15;
        zPos = Random.Range(spawnPoint.transform.position.z - 15, spawnPoint.transform.position.z + 15) ;
    }

    public static void Spawn(int numSpawn, GameObject typeMonster)
    {
        for (int i = 0; i < numSpawn; i++)
        {
            xPos = Random.Range(xPos - 5, xPos + 5);
            zPos = Random.Range(zPos - 5, zPos + 5);
            Instantiate(typeMonster, new Vector3(xPos, 2, zPos), Quaternion.identity);
            nbMonster += 1;
        }
    }
    
    IEnumerator MonstersGrrr(int sizeGroup)
    {
        {
            if (sizeGroup > 0)
            {
                yield return new WaitForSeconds(3);
                numBig = Random.Range(1, monstreRecup);
                numSmall = Random.Range(2, monstreRecup * 2);
                for (var i = 0; i < monstreRecup; i++)
                {
                    Spawn(numBig, big);
                    Spawn(numSmall, small);
                    sizeGroup -= 1;
                    yield return new WaitForSeconds(timeBetweenGroups);
                }
            }
            if (sizeGroup == 0)
            {
                yield return new WaitForSeconds(3);
                Spawn(numBoss, boss);
                numBoss -= 1;
            }
        }
    }
}
