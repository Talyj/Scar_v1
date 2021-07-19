using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenesEnter : MonoBehaviour
{
    private GameObject cameraPlayer;
    public GameObject cutSceneCam;
    private bool firstActive = true;
    private float timer;

    private GameObject boss;
    private GameObject player;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPlayer = GameObject.FindGameObjectWithTag("MainCamera");
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
            isCutscene = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & firstActive)
        {
            firstActive = false;
            cutSceneCam.SetActive(true);
            cameraPlayer.SetActive(false);
            StartCoroutine(FinishCut());
        }

        IEnumerator FinishCut()
        {
            yield return new WaitForSeconds(6);
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
        }
    }
}
