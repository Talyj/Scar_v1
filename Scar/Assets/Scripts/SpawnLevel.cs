using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate( rooms[Random.Range(0, rooms.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
