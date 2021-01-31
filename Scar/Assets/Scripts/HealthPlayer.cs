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

    void Start()
    {

    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
        statHealth.text = currentHealth + "/100";

    }
}
