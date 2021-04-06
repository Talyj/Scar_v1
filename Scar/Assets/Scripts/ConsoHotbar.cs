using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoHotbar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject amountBoard;
    private AmountBoard amounts;
    [SerializeField] private SlotsInventaire hotBar;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
    }
    public void Update()
    {
        var playerHealth = FindObjectOfType<HealthPlayer>();
        if (playerHealth.currentHealth <= playerHealth.maxHealth)
        {
            if(Input.GetKeyDown(KeyCode.F) && hotBar.isFull[0] == true) {
                if(hotBar.slots[0].transform.GetChild(0).gameObject.name == "mana_potion_hotbar(Clone)") {
                    if(amounts.amount_slot_hotbar == 1) {
                        //Mettre la ligne pour la MANA ici
                        amounts.SetHotBarMany(-1);
                        Destroy(hotBar.slots[0].transform.GetChild(0).gameObject);
                        hotBar.isFull[0] = false;
                    } else if(amounts.amount_slot_hotbar > 1) {
                        //Mettre la ligne pour la MANA ici
                        amounts.SetHotBarMany(-1);
                    }
                } else if(hotBar.slots[0].transform.GetChild(0).gameObject.name == "health_potion_hotbar(Clone)") {
                    if(amounts.amount_slot_hotbar == 1) {
                        player.GetComponent<HealthPlayer>().currentHealth += player.GetComponent<HealthPlayer>().maxHealth * 0.4f;
                        amounts.SetHotBarMany(-1);
                        Destroy(hotBar.slots[0].transform.GetChild(0).gameObject);
                        hotBar.isFull[0] = false;
                    } else if(amounts.amount_slot_hotbar > 1) {
                        player.GetComponent<HealthPlayer>().currentHealth += player.GetComponent<HealthPlayer>().maxHealth * 0.4f;
                        amounts.SetHotBarMany(-1);
                    }
                }
            }   
        }
    }
}
