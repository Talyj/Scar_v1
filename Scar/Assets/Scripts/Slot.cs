using UnityEngine;
using System.Linq;
using UnityEngine.UI; 


public class Slot : MonoBehaviour
{
    public GameObject mana_potion;
    public GameObject health_potion;

    private SlotsInventaire inventoryPart1;
    private SlotsInventaire hotbarPart;
    private GameObject inventory1;
    private GameObject hotbar;

    private GameObject amountBoard;
    private GameObject slotAmount;
    private AmountBoard amounts;
    private Transform player;
    private GameObject slotsImage;
    public GameObject itemDisplay;

    public void SwitchToHotBar(GameObject par) {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");
        var objects2 = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fourth Part HotBar");

        foreach(var item in objects) {
            inventory1 = item;
        }

        foreach(var item in objects2) {
            hotbar = item;
        }

        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();
        hotbarPart = hotbar.GetComponent<SlotsInventaire>();

        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
        int lastChildIndex = inventoryPart1.slots[0].transform.childCount - 1;
        var slotAmountss = inventoryPart1.slots[0].transform.GetChild(lastChildIndex).GetComponent<Text>();

        if(par.transform.parent.gameObject.name == "Slot 3") {
            if(inventoryPart1.slots[0].transform.GetChild(0).gameObject.name == "mana_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot3());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[0] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_3 = 0;
                    slotsImage = inventoryPart1.slots[0].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[0].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "mana_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot3(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot3() == 0) {
                                inventoryPart1.isFull[0] = false;
                                Destroy(inventoryPart1.slots[0].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[0].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            } else if(inventoryPart1.slots[0].transform.GetChild(0).gameObject.name == "health_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot3());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[0] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_3 = 0;
                    slotsImage = inventoryPart1.slots[0].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[0].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "health_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot3(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot3() == 0) {
                                inventoryPart1.isFull[0] = false;
                                Destroy(inventoryPart1.slots[0].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[0].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            }
        } else if(par.transform.parent.gameObject.name == "Slot 2") {
            if(inventoryPart1.slots[1].transform.GetChild(0).gameObject.name == "mana_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot2());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[1] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_2 = 0;
                    slotsImage = inventoryPart1.slots[1].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[1].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "mana_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot2(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot2() == 0) {
                                inventoryPart1.isFull[1] = false;
                                Destroy(inventoryPart1.slots[1].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[1].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            } else if(inventoryPart1.slots[1].transform.GetChild(0).gameObject.name == "health_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot2());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[1] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_2 = 0;
                    slotsImage = inventoryPart1.slots[1].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[1].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "health_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot2(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot2() == 0) {
                                inventoryPart1.isFull[1] = false;
                                Destroy(inventoryPart1.slots[1].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[1].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            }
        } else if(par.transform.parent.gameObject.name == "Slot 1") {
            if(inventoryPart1.slots[2].transform.GetChild(0).gameObject.name == "mana_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot1());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[2] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_1 = 0;
                    slotsImage = inventoryPart1.slots[2].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[2].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "mana_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot1(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot1() == 0) {
                                inventoryPart1.isFull[2] = false;
                                Destroy(inventoryPart1.slots[2].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[2].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            } else if(inventoryPart1.slots[2].transform.GetChild(0).gameObject.name == "health_potion_image(Clone)") {
                if(hotbarPart.isFull[0] == false) {
                    amounts.SetHotBarMany(amounts.GetAmountSlot1());
                    hotbarPart.isFull[0] = true;
                    inventoryPart1.isFull[2] = false;
                    Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
                    amounts.amount_slot_1 = 0;
                    slotsImage = inventoryPart1.slots[2].transform.GetChild(lastChildIndex).gameObject;
                    slotsImage.SetActive(false);
                    Destroy(inventoryPart1.slots[2].transform.GetChild(0).gameObject);
                } else if(hotbarPart.isFull[0] == true) {
                    if(hotbarPart.slots[0].transform.GetChild(0).gameObject.name == "health_potion_hotbar(Clone)") {
                        if(amounts.GetAmountHotBar() < 10) {
                                amounts.SetPotionSlot1(-1);
                                amounts.SetHotBarMany(1);
                            if(amounts.GetAmountSlot1() == 0) {
                                inventoryPart1.isFull[2] = false;
                                Destroy(inventoryPart1.slots[2].transform.GetChild(0).gameObject);
                                slotsImage = inventoryPart1.slots[2].transform.GetChild(lastChildIndex).gameObject;
                                slotsImage.SetActive(false);
                            }
                        } 
                    }
                }
            }
        }
    }

    public void DropPotion(GameObject par) {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");

        foreach(var item in objects) {
            inventory1 = item;
        }

        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        int i = 3;

        if(par.transform.parent.gameObject.name == "Slot 3") {
            i = 0;
        } else if(par.transform.parent.gameObject.name == "Slot 2") {
            i = 1;
        } else if(par.transform.parent.gameObject.name == "Slot 1") {
            i = 2;
        }

        int lastChildIndex = inventoryPart1.slots[i].transform.childCount - 1;
        Debug.Log(i);

        if(inventoryPart1.slots[i].transform.GetChild(0).gameObject.name == "mana_potion_image(Clone)") {
            if((amounts.GetAmountSlot3() == 1 && i == 0) || (amounts.GetAmountSlot2() == 1 && i == 1) || (amounts.GetAmountSlot1() == 1 && i == 2)) {
                ChangeNumberOfPotion(i, inventoryPart1, lastChildIndex);
                inventoryPart1.isFull[i] = false;
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject);
                slotsImage = inventoryPart1.slots[i].transform.GetChild(lastChildIndex).gameObject;
                slotsImage.SetActive(false);
                Vector3 playerPos = new Vector3(player.position.x + 3, player.position.y + 2, player.position.z);
                Instantiate(mana_potion, playerPos, Quaternion.identity);
            } else {
                ChangeNumberOfPotion(i, inventoryPart1, lastChildIndex);
                Vector3 playerPos = new Vector3(player.position.x + 3, player.position.y + 2, player.position.z);
                Instantiate(mana_potion, playerPos, Quaternion.identity);
            }
        } else if(inventoryPart1.slots[i].transform.GetChild(0).gameObject.name == "health_potion_image(Clone)") {
            if(amounts.GetAmountSlot3() == 1 && i == 0 || amounts.GetAmountSlot2() == 1 && i == 1 || amounts.GetAmountSlot1() == 1 && i == 2) {
                ChangeNumberOfPotion(i, inventoryPart1, lastChildIndex);
                inventoryPart1.isFull[i] = false;
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject);
                slotsImage = inventoryPart1.slots[i].transform.GetChild(lastChildIndex).gameObject;
                slotsImage.SetActive(false);
                Vector3 playerPos = new Vector3(player.position.x + 3, player.position.y + 2, player.position.z);
                Instantiate(health_potion, playerPos, Quaternion.identity);
            } else {
                ChangeNumberOfPotion(i, inventoryPart1, lastChildIndex);
                Vector3 playerPos = new Vector3(player.position.x + 3, player.position.y + 2, player.position.z);
                Instantiate(health_potion, playerPos, Quaternion.identity);
            }
        }
    }

    private void ChangeNumberOfPotion(int x, SlotsInventaire inventoryPart1, int lastChildIndex) {
        var slotAmounts = inventoryPart1.slots[x].transform.GetChild(lastChildIndex).GetComponent<Text>();
        if(x == 0) {
            amounts.amount_slot_3 = amounts.amount_slot_3 - 1;
            slotAmounts.text = amounts.amount_slot_3.ToString();
        } else if(x == 1) {
            amounts.amount_slot_2 = amounts.amount_slot_2 - 1;
            slotAmounts.text = amounts.amount_slot_2.ToString();
        } else if(x == 2) {
            amounts.amount_slot_1 = amounts.amount_slot_1 - 1;
            slotAmounts.text = amounts.amount_slot_1.ToString();
        }
    }
}
