using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBehaviour : MonoBehaviour
{
    private Transform player;
    private int speed = 20;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Deplacement();
        if (enemies.Length == 0)
        {
            SpawnEnemy.nbMonster -= 1;
            Destroy(gameObject);
        }
    }

    private void Deplacement()
    {
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
