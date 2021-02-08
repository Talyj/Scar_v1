using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    public Image healthFill;
    public Text statHealth;
    public float maxHealth = 100;
    public float currentHealth = 100;

    public GameObject death;

    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
        statHealth.text = currentHealth + "/100";

        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            death.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulEnemy"))
        {
            currentHealth -= 5;
            PlayerController.numberDamagesReceived += 5;
            PlayerController.score -= 1;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 10;
            PlayerController.numberDamagesReceived += 10;
            PlayerController.score -= 5;
        }
    }

}
