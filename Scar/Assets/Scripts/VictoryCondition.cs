using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        BossBehaviour.isAlive = 1;
        KorinhBehaviour.isAlive = 1;
        BobbBehaviour.isAlive = 1;
        FlueBehaviour.isAlive = 1;
    }

    void Update()
    {
        if (BossBehaviour.isAlive == 0 || KorinhBehaviour.isAlive == 0 || BobbBehaviour.isAlive == 0 || FlueBehaviour.isAlive == 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
