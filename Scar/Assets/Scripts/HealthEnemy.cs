using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField]
    public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    public float degats = 35;
    private int deg;

    private void Start()
    {
        deg.Equals(degats);
        if (GameObject.FindGameObjectWithTag("Attaque"))
        {
            degats = degats * 110 / 100;
        }

        //if (GameObject.FindGameObjectWithTag("Attaque2"))
        //{
            //degats = degats * 120 / 100;
        //}
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            if (maxHealth > 200)
            {
                PlayerController.score += 30;
            }
            else
            {
                PlayerController.score += 10;
            }
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulBasic"))
        {
            currentHealth -= degats;
            PlayerController.numberDamagesDealt += deg;
            Destroy(collision.gameObject);
        }
    }
}
