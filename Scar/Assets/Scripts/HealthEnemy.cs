using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField]
    public Image healthFill;
    public float maxHealth = 100;
    public float currentHealth = 100;

    void Start()
    {
        
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulBasic"))
        {
            currentHealth -= 35;
            Destroy(collision.gameObject);
        }
    }
}
