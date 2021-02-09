using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    void Update()
    {
        if (SpawnEnemy.nbMonster == 0)
        {
            panel.SetActive(true);
        }
    }
}
