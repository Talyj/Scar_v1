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
    public float degatsBullet = 35;
    public float degatWeapon = 50;

    private void Start()
    {
        BossBehaviour.isAlive = 1;
        if (GameObject.FindGameObjectWithTag("Attaque"))
        {
            degatsBullet = degatsBullet * 110 / 100;
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
            currentHealth -= degatsBullet;
            PlayerController.numberDamagesDealt += degatsBullet;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ZoneAttaqueNormal"))
        {
            currentHealth -= degatWeapon;
            PlayerController.numberDamagesDealt += degatWeapon;
        }
    }
}
