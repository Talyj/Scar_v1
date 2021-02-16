using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public GameObject big;
    public GameObject small;
    private int xPos;
    private int zPos;

    private int numBig;
    private  int numSmall;

    public int numSmallGroup = 0;
    public int numMediumGroup = 0;
    public int numBigGroup = 0;
    public int timeBetweenGroups;
    
    public static int nbMonster;
    
    void Start()
    {
        StartCoroutine(MonstersGrrr());
    }

    void Spawn(int numSpawn, GameObject typeMonster)
    {
        for (int i = 1; i < numSpawn + 1; i++)
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(-15, 22);
            Instantiate(typeMonster, new Vector3(xPos, 2, zPos), Quaternion.identity);
            nbMonster += 1;
        }
    }
    
    IEnumerator MonstersGrrr()
    {
        if (numSmallGroup != 0)
        {
            numBig = Random.Range(1, 2);
            numSmall = Random.Range(2, 4);
            for (var i = 0; i < numSmallGroup; i++)
            {
                Spawn(numBig, big);
                Spawn(numSmall, small);
                yield return new WaitForSeconds(timeBetweenGroups);
            }
        }
        
        if (numMediumGroup != 0)
        {
            numBig = Random.Range(2, 3);
            numSmall = Random.Range(4, 6);
            for (var i = 0; i < numSmallGroup; i++)
            {
                Spawn(numBig, big);
                Spawn(numSmall, small);
                yield return new WaitForSeconds(timeBetweenGroups);
            }
        }
        
        if (numBigGroup != 0)
        {
            numBig = Random.Range(4, 5);
            numSmall = Random.Range(8, 10);
            for (var i = 0; i < numSmallGroup; i++)
            {
                Spawn(numBig, big);
                Spawn(numSmall, small);
                yield return new WaitForSeconds(timeBetweenGroups);
            }
        }
    }
}
