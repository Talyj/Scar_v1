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
    public float degatsBalle = 10;
    public float degatsCol = 5;
    private int degB;
    private int degC;

    public GameObject death;

    void Start()
    {
        Time.timeScale = 1f;
        degB.Equals(degatsBalle);
        degC.Equals(degatsCol);

        if (GameObject.FindGameObjectWithTag("Shield"))
        {
            degatsBalle = degatsBalle * 90/100;
            degatsCol = degatsCol * 90 / 100;
        }

        if (GameObject.FindGameObjectWithTag("Shield2"))
        {
            degatsBalle = degatsBalle * 80 / 100;
            degatsCol = degatsCol * 80 / 100;
        }
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
            currentHealth -= degatsCol;
            PlayerController.numberDamagesReceived += degC;
            PlayerController.score -= 1;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= degatsBalle;
            PlayerController.numberDamagesReceived += degB;
            PlayerController.score -= 5;
        }
    }

}
