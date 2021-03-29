using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private HealthEnemy health;
    [SerializeField] private float defaultSpeedMonster;
    private float speed;
    
    [SerializeField] private float timeBetweenShots = 3;
    private float shotCounter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        speed = defaultSpeedMonster;
        if (health.maxHealth == 70)
        {
            float dist = Vector3.Distance(gameObject.transform.position, player.position);
            if (dist <= 20)
            {
                speed = 0;
            }
        }

        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;

        
        
        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
}
