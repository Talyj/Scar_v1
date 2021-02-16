using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject big;
    public GameObject small;
    private int xPos;
    private int zPos;

    public int numBig;
    public int numSmall;
    
    public static int nbMonster;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i =1; i < numBig + 1; i++)
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(-15, 22);
            Instantiate(big, new Vector3(xPos, 2, zPos), Quaternion.identity);
            nbMonster += 1;
            yield return new WaitForSeconds(2);
        }

        for (int i = 1; i < numSmall + 1; i++)
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(-15, 22);
            Instantiate(small, new Vector3(xPos, 2, zPos), Quaternion.identity);
            nbMonster += 1;
            yield return new WaitForSeconds(2);
        }

    }
}
