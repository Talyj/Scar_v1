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
        nbBulletText.text = "Nombre de bullet : " + PlayerController.numberBullets.ToString();
        nbDamageReceivedText.text = "Dégât reçu : " + PlayerController.numberDamagesReceived.ToString();
        nbDamageDealtText.text = "Dégât Effectué : " + PlayerController.numberDamagesDealt.ToString();
        scoreText.text ="Score : " +  PlayerController.score.ToString();
    }
}
