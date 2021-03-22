using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    
    void Update()
    {
        if (BossBehaviour.isAlive == 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
