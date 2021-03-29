using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using Random = UnityEngine.Random;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject spawnPoint;
    private int maxRoom = 3;
    [SerializeField] private GameObject bossRoom;
    [SerializeField] private GameObject porte;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.cpt >= maxRoom)
            {
                Instantiate(bossRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            else
            {
                int typeRoom = Random.Range(0, rooms.Length);
                Instantiate( rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 1);
            Instantiate(porte, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
