using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] private HealthEnemy health;
    [SerializeField] private float defaultSpeedMonster;
    public static float speed;
    private float shotCounter;
    private bool isUp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        //Pot
        speed = defaultSpeedMonster;
        if (health.maxHealth == 70)
        {
            if (dist <= 20)
            {
                speed = 0;
            }
        }

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
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
