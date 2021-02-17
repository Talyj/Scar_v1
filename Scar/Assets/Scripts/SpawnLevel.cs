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
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int typeRoom = Random.Range(0, rooms.Length);
            Instantiate( rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 1);
        }
    }
}
