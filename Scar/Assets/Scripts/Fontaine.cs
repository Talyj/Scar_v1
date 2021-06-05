using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fontaine : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    [SerializeField] private Transform[] spawnpointLoots;
    
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject rubis;
    [SerializeField] private GameObject health_potion;
    [SerializeField] private GameObject mana_potion;
    [SerializeField] private GameObject damage_potion;
    [SerializeField] private GameObject shield_potion;
    [SerializeField] private GameObject destruct_potion;
    
    private Boolean firstSpawn;
    private Boolean lootSpawned;

    // Update is called once per frame
    private void Start()
    {
        firstSpawn = true;
        lootSpawned = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (firstSpawn)
            {
                other.GetComponent<Transform>().position = new Vector3(respawn.position.x, other.GetComponent<Transform>().position.y, respawn.position.z);
                firstSpawn = false;
            }
            else if (!lootSpawned)
            {
                lootSpawned = true;
                foreach (var spawnpoint in spawnpointLoots)
                {
                    Instantiate(coin, spawnpoint.position, Quaternion.identity);
                    var xPos  = spawnpoint.position.x + Random.Range(-5, 5);
                    var zPos  = spawnpoint.position.z + Random.Range(-5, 5);
                    Instantiate(rubis, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);
                    Instantiate(health_potion, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);   
                    Instantiate(mana_potion, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);
                    Instantiate(damage_potion, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);   
                    Instantiate(shield_potion, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);
                    Instantiate(destruct_potion, new Vector3(xPos, spawnpoint.position.y, zPos), Quaternion.identity);
                }
            }
        }
    }
}
