using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenesEnter : MonoBehaviour
{
    public GameObject cameraPlayer;
    public GameObject cutSceneCam;
    private bool firstActive = true;
    private float timer;

    private GameObject boss;
    private GameObject player;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
        player = GameObject.FindGameObjectWithTag("Player");
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
            yield return new WaitForSeconds(2);
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
        }
        
        IEnumerator ResumeAfterNSeconds(float timePeriod)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.unscaledDeltaTime;
            if(timer < timePeriod)
                StartCoroutine(ResumeAfterNSeconds(3.0f));
            else
            {
                Time.timeScale = 1;                //Resume
                timer = 0;
            }
        }
    }
}
