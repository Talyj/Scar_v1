using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject spawnPoint;
    private int firstPart;
    private int secondPart;
    [SerializeField] private GameObject LymuleRoom;
    [SerializeField] private GameObject KorinhRoom;
    [SerializeField] private GameObject BobbRoom;
    [SerializeField] private GameObject FlueRoom;
    [SerializeField] private GameObject miniBossRoom;
    [SerializeField] private GameObject porte;
    [SerializeField] private GameObject room;
    private bool hasSpawn;
    private bool endFirstPart;


    private void Awake()
    {
        //firstPart = Random.Range(3, 4);
        firstPart = 1;
        //secondPart = firstPart + Random.Range(2, 4);
        secondPart = firstPart + 1;
        endFirstPart = false;
        
    }

    private void Start()
    {
        hasSpawn = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasSpawn == false)
        {
            if (PlayerController.cpt == firstPart && PlayerController.cpt < secondPart && endFirstPart != true)
            {
                Instantiate(miniBossRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
                endFirstPart = true;
            }
            else if( PlayerController.cpt >= secondPart)
            {
                if (SceneManager.GetActiveScene().name == "Main")
                {
                    Instantiate(LymuleRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    hasSpawn = true;   
                }
                else if (SceneManager.GetActiveScene().name == "Donjon2")
                {
                    Instantiate(KorinhRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    hasSpawn = true;
                }
                else if (SceneManager.GetActiveScene().name == "Donjon3")
                {
                    Instantiate(BobbRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    hasSpawn = true;
                }
                else if (SceneManager.GetActiveScene().name == "Donjon4")
                {
                    Instantiate(FlueRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    hasSpawn = true;
                }
            }
            else
            {
                int typeRoom = Random.Range(0, rooms.Length);
                Instantiate( rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            Destroy(room, 1);
        }
    }
}
