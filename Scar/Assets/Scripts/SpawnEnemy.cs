using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject big;
    public  GameObject small;
    public  GameObject boss;
    private static float xPos;
    private static float zPos;

    private int numBig;
    private  int numSmall;

    public int numMonsters;
    public int numBoss;
    public int timeBetweenGroups;
    
    public static int nbMonster;

    private GameObject door;
    private GameObject spawnPoint;
    
    void Start()
    {
        StartCoroutine(MonstersGrrr(numMonsters));
    }

    private void Update()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Gate");
        xPos = Random.Range(spawnPoint.transform.position.x - 20, spawnPoint.transform.position.x + 20) ;
        zPos = Random.Range(spawnPoint.transform.position.z, spawnPoint.transform.position.z - 50) ;
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
            if (sizeGroup >= 0)
            {
                numBig = Random.Range(1, numMonsters);
                numSmall = Random.Range(2, numMonsters * 2);
                for (var i = 0; i < numMonsters; i++)
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
