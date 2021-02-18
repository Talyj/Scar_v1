using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;

        if (transform.position.y <= -20)
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
