using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public int maxHealth;
    public float currentHealth;

    private void Start()
    {
        if (gameObject.name == "Lymule")
        {
            BobbBehaviour.isAlive = 1;   
        }
        else if (gameObject.name == "Korinh")
        {
            KorinhBehaviour.isAlive = 1;
        }
        else if (gameObject.name == "Bobb")
        {
            BobbBehaviour.isAlive = 1;
        }
        else if (gameObject.name == "Flue")
        {
            FlueBehaviour.isAlive = 1;
        }
        
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);

            if(currentHealth <= 0 && BobbBehaviour.isAlive == 1)
            {
                BobbBehaviour.isAlive = 0;
                GameInfo.levelBoss = 3;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
                Destroy(gameObject);
            }
        }
    }
}
