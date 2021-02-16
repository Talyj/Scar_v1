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
    public GameObject firstRoom;
    private GameObject oldRoom;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int typeRoom = Random.Range(0, rooms.Length);
            Instantiate( rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
            try
            {
                Destroy(firstRoom, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Nothing to see here >.>");
            }
            oldRoom = rooms[typeRoom];
            Destroy(oldRoom, 1);
        }
    }

}
