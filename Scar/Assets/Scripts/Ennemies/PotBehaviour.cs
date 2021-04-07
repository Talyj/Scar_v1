using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    private Transform player;
    private float speedMonster = 6;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Deplacement();
    }

    // Start is called before the first frame update
    private void Deplacement()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 20)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            transform.position += -transform.forward * Time.deltaTime * speedMonster;
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speedMonster;   
        }

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            SpawnEnemy.nbMonster--;
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
}
