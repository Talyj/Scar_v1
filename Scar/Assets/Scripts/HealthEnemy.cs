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
            SpawnEnemy.nbMonster -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulBasic"))
        {
            currentHealth -= 35;
            PlayerController.numberDamagesDealt += 35;
            Destroy(collision.gameObject);
        }
    }
}
