using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistiques : MonoBehaviour
{
    [SerializeField] private Text nbBulletText;
    [SerializeField] private Text nbDamageReceivedText;
    [SerializeField] private Text nbDamageDealtText;
    [SerializeField] private Text scoreText;
    
    void Start()
    {
        nbDamageReceivedText = GetComponent<Text>();
        nbDamageDealtText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        nbBulletText.text = "Nombre de bullet : " + PlayerController.numberBullets.ToString();
        nbDamageReceivedText.text = PlayerController.numberDamagesReceived.ToString();
        nbDamageDealtText.text = PlayerController.numberDamagesDealt.ToString();
        scoreText.text = PlayerController.score.ToString();

    }
}
