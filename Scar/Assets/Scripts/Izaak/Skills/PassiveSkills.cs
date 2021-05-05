using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    private bool berserker1;
    private bool berserker2;
    private void Start()
    {
        berserker1 = false;
        berserker2 = false;
    }

    private void Update()
    {
        switch (GameInfo.passiveSkill)
        {
            case "berserker":
                Berserker();
                break;
            case "rempart":
                
                break;
            case "rewind":
                
                break;
        }
        Debug.Log(GameInfo.rangedDamage); 
    }

    private void Berserker()
    {
        switch (GameInfo.passiveLevel)
        {
            case 1:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 1.2f;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.1f;
                    berserker1 = true;
                }
                break;
            case 2:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 1.5f;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.3f;
                    berserker1 = true;
                }
                break;
            case 3:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 2;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.5f;
                    berserker1 = true;
                }
                break;
        }

    }
}
