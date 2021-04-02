using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    [SerializeField] private HealthEnemy healthPit;
    [SerializeField] private GameObject pit;
    private bool HasSpawn = false;

    void Update()
    {
        if (healthPit.currentHealth <= 40 && HasSpawn == false)
        {
            if (healthPit.maxHealth == 300)
            {
                SpawnEnemy.Spawn(2, pit);
                HasSpawn = true;
            }
            
            if(healthPit.maxHealth == 150)
            {
                SpawnEnemy.Spawn(4, pit);
                HasSpawn = true;
            }   
        }
    }
}
