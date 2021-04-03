using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoHotbar : MonoBehaviour
{
    private GameObject player;
    public GameObject amount_slot_hotbar_hotbar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && AmountBoard.amount_slot_hotbar > 0)
        {
            player.GetComponent<HealthPlayer>().currentHealth += 50;  
            AmountBoard.amount_slot_hotbar -= 1;

            AmountBoard.amount_slot_hotbar = AmountBoard.amount_slot_hotbar + -1;
            var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
            p.text = "oeoeoeoeoe "; //AmountBoard.amount_slot_hotbar.ToString();
            if (AmountBoard.amount_slot_hotbar >= 1)
            {
                amount_slot_hotbar_hotbar.SetActive(true);
            }
            else if (AmountBoard.amount_slot_hotbar == 0)
            {
                amount_slot_hotbar_hotbar.SetActive(false);
            }
        }
    }
}
