using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
     SpawnEnemy trigger;
    [SerializeField] private Animator door;

    void Start()
    {
        trigger = GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnEnemy.open == true)
        {
            door.Play("OuverturePorteDonjon", -1, 0f);
        }
    }
}
