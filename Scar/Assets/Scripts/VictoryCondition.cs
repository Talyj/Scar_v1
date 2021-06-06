using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    void Update()
    {
        if (BossBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || KorinhBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || BobbBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || FlueBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
