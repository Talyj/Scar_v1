using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.IO;

public class SpawnLevelEditMap : MonoBehaviour
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
    private string chemin, jsonString;

    private int typeRoom;

    private void Awake() { 
        chemin = Application.streamingAssetsPath + "/EditeurMap.json";
        jsonString = File.ReadAllText(chemin);
        VariableJSON editionMap = JsonUtility.FromJson<VariableJSON>(jsonString);
    }

    private void Start()
    {
        hasSpawn = false;
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player") && hasSpawn == false)
        {
            chemin = Application.streamingAssetsPath + "/EditeurMap.json";
            jsonString = File.ReadAllText(chemin);
            VariableJSON editionMap = JsonUtility.FromJson<VariableJSON>(jsonString);
            if (PlayerController.cpt == Mathf.Round(editionMap.nb_salles/2) && endFirstPart != true)
            {
                Instantiate(miniBossRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
                endFirstPart = true;
            }
            else if( PlayerController.cpt >= editionMap.nb_salles)
            {
                Instantiate(LymuleRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                hasSpawn = true;   
            }
            else
            {   
                if(PlayerController.cpt <= 1) {
                    if(editionMap.type_salle_1 == "null" || editionMap.type_salle_1 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_1 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_1 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_1 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_1 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 2) {
                    if(editionMap.type_salle_2 == "null" || editionMap.type_salle_2 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_2 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_2 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_2 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_2 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 3) {
                    if(editionMap.type_salle_3 == "null" || editionMap.type_salle_3 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_3 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_3 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_3 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_3 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 4) {
                    if(editionMap.type_salle_4 == "null" || editionMap.type_salle_4 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_4 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_4 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_4 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_4 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 5) {
                    if(editionMap.type_salle_5 == "null" || editionMap.type_salle_5 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_5 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_5 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_5 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_5 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 6) {
                    if(editionMap.type_salle_6 == "null" || editionMap.type_salle_6 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_6 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_6 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_6 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_6 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 7) {
                    if(editionMap.type_salle_7 == "null" || editionMap.type_salle_7 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_7 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_7 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_7 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_7 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 8) {
                    if(editionMap.type_salle_8 == "null" || editionMap.type_salle_8 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_8 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_8 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_8 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_8 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 9) {
                    if(editionMap.type_salle_9 == "null" || editionMap.type_salle_9 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_9 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_9 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_9 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_9 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 10) {
                    if(editionMap.type_salle_10 == "null" || editionMap.type_salle_10 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_10 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_10 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_10 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_10 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 11) {
                    if(editionMap.type_salle_11 == "null" || editionMap.type_salle_11 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_11 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_11 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_11 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_11 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 12) {
                    if(editionMap.type_salle_12 == "null" || editionMap.type_salle_12 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_12 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_12 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_12 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_12 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 13) {
                    if(editionMap.type_salle_13 == "null" || editionMap.type_salle_13 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_13 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_13 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_13 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_13 == "salle5") {
                        typeRoom = 4;
                    }
                } else if(PlayerController.cpt == 14) {
                    if(editionMap.type_salle_14 == "null" || editionMap.type_salle_14 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_14 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_14 == "salle3") {
                        typeRoom = 2;
                    } else if(editionMap.type_salle_14 == "salle4") {
                        typeRoom = 3;
                    } else if(editionMap.type_salle_14 == "salle5") {
                        typeRoom = 4;
                    }
                }
                GameObject newRoom = Instantiate(rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
                Debug.Log("Numéro de la salle : " + PlayerController.cpt);
                Debug.Log("Type de la salle : " + typeRoom + " (de 0 à 4)");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(room, 1);
        }
    }
}
