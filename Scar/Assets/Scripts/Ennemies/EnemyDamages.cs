using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamages : MonoBehaviour
{
    private HealthPlayer player;
    [SerializeField] private float degats;

    private void Start()
    {
        player = FindObjectOfType<HealthPlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.currentHealth -= degats;
            PlayerController.numberDamagesReceived += degats;
            PlayerController.score -= 1;
        }
    }
}
