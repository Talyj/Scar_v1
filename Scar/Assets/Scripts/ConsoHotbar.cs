using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoHotbar : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private SlotsInventaire hotBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && AmountBoard.amount_slot_hotbar > 0)
        {
            player.GetComponent<HealthPlayer>().currentHealth += player.GetComponent<HealthPlayer>().maxHealth * 0.6f;
            AmountBoard.amount_slot_hotbar -= 1;
        }
    }
}
