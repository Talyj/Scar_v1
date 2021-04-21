using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlueHealth : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    public float degatsBullet = GameInfo.rangedDamage;
    public float degatWeapon = GameInfo.closedDamage;

    private void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        player = thePlayer.GetComponent<PlayerController>();
        
        FlueBehaviour.isAlive = 1;
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

            if(currentHealth <= 0 && FlueBehaviour.isAlive == 1)
            {
                FlueBehaviour.isAlive = 0;
                GameInfo.levelBoss = 4;
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