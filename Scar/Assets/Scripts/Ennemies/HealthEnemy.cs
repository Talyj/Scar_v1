using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    public float degatsBullet = 35;
    public float degatWeapon = 50;

    public GameObject coin;
    public GameObject rubis;
    public GameObject mana_potion;
    public GameObject health_potion;

    private void Start()
    {
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

            dropPotion();
            dropCoinAndRubis(0, 2, rubis);
            dropCoinAndRubis(10, 50, coin);
            SpawnEnemy.nbMonster -= 1;
            new WaitForSeconds(0.1f);
            Destroy(gameObject);
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

    private void dropCoinAndRubis(int x, int y, GameObject g) {
        int coins = Random.Range(x, y); 
        transform.position = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 2, transform.position.z + Random.Range(-2, 2));
        Instantiate(g, transform.position, Quaternion.Euler (90f, Random.Range(-45f, 45f), 0f));
    }

    private void dropPotion() {
        int i = Random.Range(0, 3);
        transform.position = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 2, transform.position.z + Random.Range(-2, 2));
        if(i == 1) {
            Instantiate(mana_potion, transform.position, Quaternion.Euler (90f, Random.Range(-45f, 45f), 0f));
        } else if(i == 2) {
            Instantiate(health_potion, transform.position, Quaternion.Euler (90f, Random.Range(-45f, 45f), 0f));
        }
    }
}
