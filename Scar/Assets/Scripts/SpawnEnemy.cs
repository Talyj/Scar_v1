using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject big;
    public GameObject small;
    public int xPos;
    public int zPos;

    public int numBig; // Nombre de mobs gros
    public int numSmall; // Nombre de mobs petits
    
    void Start()
    {
        StartCoroutine(SpawnBig());
        StartCoroutine(SpawnLittle());

    }
    
    IEnumerator SpawnBig()
    {
        for (int i =1; i < numBig + 1; i++)  // Spawn des gros mobs 
        {
            Instantiate(big, new Vector3(Random.Range(-20, 20), 2, Random.Range(17, 25)), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnLittle()
    {
        for (int j = 1; j < numSmall + 1; j++) // Spawn des petits mobs
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(17, 25);
            Instantiate(small, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
