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
    [SerializeField] public static int maxRoom;
    [SerializeField] private GameObject bossRoom;
    public static int roomRecup;
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.cpt >= roomRecup)
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
        }
    }
}
