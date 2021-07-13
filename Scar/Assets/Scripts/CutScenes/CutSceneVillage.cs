using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneVillage : MonoBehaviour
{
    private GameObject cameraPlayer;
    public GameObject cutSceneCam;
    private bool firstActive = true;
    private float timer;

    private void Start()
    {
        cameraPlayer = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & firstActive)
        {
            firstActive = false;
            cutSceneCam.SetActive(true);
            cameraPlayer.SetActive(false);
            StartCoroutine(FinishCut(13));
        }

        IEnumerator FinishCut(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
        }
    }
}
