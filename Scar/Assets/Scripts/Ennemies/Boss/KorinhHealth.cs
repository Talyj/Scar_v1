using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KorinhHealth : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    public float degatsBullet = 35;
    public float degatWeapon = 50;

    private void Start()
    {
        KorinhBehaviour.isAlive = 1;
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
            Destroy(gameObject);

            if(currentHealth <= 0 && KorinhBehaviour.isAlive == 1)
            {
                KorinhBehaviour.isAlive = 0;
                PlayerController.korinhDead = true;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
                Destroy(gameObject);
            }
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
    }
}