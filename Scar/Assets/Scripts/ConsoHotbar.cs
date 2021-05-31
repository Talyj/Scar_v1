using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ConsoHotbar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventory1;
    [SerializeField] private GameObject hotbar;
    private SlotsInventaire hotbarPart;
    private SlotsInventaire inventoryPart1;
    private GameObject amountBoard;
    private AmountBoard amounts;

    private void Awake() {
        //player = GameObject.FindGameObjectWithTag("Player");
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
        hotbarPart = hotbar.GetComponent<SlotsInventaire>();
        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();
    }

    public void Update() {
        CheckTypeHotBar();
        CheckTypeSlot1();
        CheckTypeSlot2();
        CheckTypeSlot3();
        if(Input.GetKeyDown(KeyCode.F) && hotbarPart.isFull[0] == true) { // Si on appuie sur F et que la hotbar est pleine, on utilise la potion
            switch(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag) {
                case "DamagePotionHotbar":
                    CheckAmountHotBar();
                    Debug.Log("damage");
                    break;
                case "DestructPotionHotbar":
                    CheckAmountHotBar();
                    Debug.Log("destruct");
                    break;
                case "ShieldPotionHotbar":
                    CheckAmountHotBar();
                    Debug.Log("shield");
                    break;
                case "ManaPotionHotbar":
                    CheckAmountHotBar();
                    Debug.Log("mana");
                    break;
                case "HealthPotionHotbar":
                    CheckAmountHotBar();
                    Debug.Log("health");
                    break;
                default:
                    break;
            }
        }
    }

    //*** Permet de supprimer par utilisation une potion de la hotbar ***//
    private void CheckAmountHotBar() {
        if(amounts.GetAmountHotBar() == 1) {
            amounts.SetHotBarMany(-1);
            Destroy(hotbarPart.slots[0].transform.GetChild(0).gameObject);
            hotbarPart.isFull[0] = false;
        } else if(amounts.GetAmountHotBar() > 1) {
            amounts.SetHotBarMany(-1);
        }
    }


    //*** Permet de set le type de potion présent dans la hotbar ***//
    private void CheckTypeHotBar() {
        switch(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag) {
            case "DestructPotionHotbar":
                amounts.SetHotbarType("destruct_potion");
                break;
            case "DamagePotionHotbar":
                amounts.SetHotbarType("damage_potion");
                break;
            case "HealthPotionHotbar":
                amounts.SetHotbarType("heal_potion");
                break;
            case "ManaPotionHotbar":
                amounts.SetHotbarType("mana_potion");
                break;
            case "ShieldPotionHotbar":
                amounts.SetHotbarType("shield_potion");
                break;
            default:
                amounts.SetHotbarType("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 3 ***//
    private void CheckTypeSlot3() {
        switch(inventoryPart1.slots[2].transform.GetChild(0).gameObject.tag) {
            case "DestructPotionInventory":
                amounts.SetSlot3Type("destruct_potion");
                break;
            case "DamagePotionInventory":
                amounts.SetSlot3Type("damage_potion");
                break;
            case "ShieldPotionInventory":
                amounts.SetSlot3Type("shield_potion");
                break;
            default:
                amounts.SetSlot3Type("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 2 ***//
    private void CheckTypeSlot2() {
        switch(inventoryPart1.slots[1].transform.GetChild(0).gameObject.tag) {
            case "ManaPotionInventory":
                amounts.SetSlot2Type("mana_potion");
                break;
            default:
                amounts.SetSlot2Type("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 1 ***//
    private void CheckTypeSlot1() {
        switch(inventoryPart1.slots[0].transform.GetChild(0).gameObject.tag) {
            case "HealthPotionInventory":
                amounts.SetSlot1Type("heal_potion");
                break;
            default:
                amounts.SetSlot1Type("null");
                break;
        }
    }
}
