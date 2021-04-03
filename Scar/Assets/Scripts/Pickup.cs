using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; 

public class Pickup : MonoBehaviour
{
    private SlotsInventaire inventoryPart1;
    private SlotsInventaire inventoryPart2;
    private SlotsInventaire inventoryPart3;
    private SlotsInventaire inventoryPart4;
    private SlotsInventaire inventoryPart5;
    private GameObject inventory1;
    private GameObject inventory2;
    private GameObject inventory3;
    private GameObject inventory4;
    private GameObject inventory5;

    private GameObject amountBoard;
    private AmountBoard amounts;

    public GameObject itemButton;
    public GameObject itemDisplay;

    private void Start() {
    } 

    void OnTriggerEnter(Collider col) {
        if(col.name == "Player") {
            switch(itemButton.name) {
                case "health_potion_loot(Clone)":
                    isPotion();
                    break;
                case "mana_potion_loot(Clone)":
                    isPotion();
                    break;
                case "piece_loot(Clone)":
                    isCoinOrRubis("piece");
                    break;
                case "rubis_loot(Clone)":
                    isCoinOrRubis("rubis");
                    break;
                default:
                    Debug.Log("Item Inconnu!");
                    break;
            }
        }
    }

    void isPotion() {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();

        foreach(var item in objects) {
            inventory1 = item;
        }

        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();

        for(int i = 0; i < inventoryPart1.slots.Length; i++) {
            if(inventoryPart1.isFull[i] == false) {
                inventoryPart1.isFull[i] = true;
                Instantiate(itemDisplay, inventoryPart1.slots[i].transform, false);
                amounts.SetPotion(i, 1);
                Destroy(gameObject);
                break;
            } else if(inventoryPart1.isFull[i] == true) {
                if(inventoryPart1.slots[i].transform.GetChild(0).gameObject.name == "mana_potion_image(Clone)" && itemButton.name == "mana_potion_loot(Clone)") {
                    if(amounts.GetPotion(i) < 10) {
                        amounts.SetPotion(i, 1);
                        Destroy(gameObject);
                        break;
                    }
                } else if(inventoryPart1.slots[i].transform.GetChild(0).gameObject.name == "health_potion_image(Clone)" && itemButton.name == "health_potion_loot(Clone)") {
                    if(amounts.GetPotion(i) < 10) {
                        amounts.SetPotion(i, 1);
                        Destroy(gameObject);
                        break;
                    }
                } 
            }
        }
    }

    void isCoinOrRubis(string t) {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fifth Part");
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
        
        foreach(var item in objects) {
            inventory5 = item;
        }

        inventoryPart5 = inventory5.GetComponent<SlotsInventaire>();

        if(t == "piece") {
            if(inventoryPart5.isFull[0] == false) {
                inventoryPart5.isFull[0] = true;
                amounts.SetPiece(1);
                Instantiate(itemDisplay, inventoryPart5.slots[0].transform, false);
                Destroy(gameObject);
            } else if(inventoryPart5.isFull[0] == true) {
                amounts.SetPiece(1);
                Destroy(gameObject);
            }
        } else if(t == "rubis") {
            if(inventoryPart5.isFull[2] == false) {
                inventoryPart5.isFull[2] = true;
                amounts.SetRubis(1);
                Instantiate(itemDisplay, inventoryPart5.slots[2].transform, false);
                Destroy(gameObject);
            } else if(inventoryPart5.isFull[2] == true) {
                amounts.SetRubis(1);
                Destroy(gameObject);
            }
        }
    }
}
