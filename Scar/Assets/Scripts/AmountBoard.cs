using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.Linq;

public class AmountBoard : MonoBehaviour {

    private int amount_piece = 0;
    private int amount_rubis = 0;
    private int amount_slot_1 = 0;
    private int amount_slot_2 = 0;
    private int amount_slot_3 = 0;
    private int amount_slot_hotbar = 0;
    public GameObject amount_piece_object;
    public GameObject amount_rubis_object;
    public GameObject amount_slot_object_1;
    public GameObject amount_slot_object_2;
    public GameObject amount_slot_object_3;
    public GameObject amount_slot_hotbar_hotbar;
    private SlotsInventaire slotsPiece;
    private SlotsInventaire slotsPotion;
    private SlotsInventaire slotsHotbar;
    private GameObject itemPiece;
    private GameObject itemRubis;
    private GameObject itemPotion1;
    private GameObject itemPotion2;
    private GameObject itemPotion3;
    private GameObject itemPotionHotbar;
    private string hotbar_type;
    private string slot3_type; 
    private string slot2_type;
    private string slot1_type; 

    void Awake() {
        SearchAllSlots();
        slotsPiece = null;
        slotsPotion = null;
        slotsHotbar = null;
        itemPiece = null;
        itemRubis = null;
        itemPotion1 = null;
        itemPotion2 = null;
        itemPotion3 = null;
        itemPotionHotbar = null;
    }

    //*** Met à jour l'inventaire même en changeant la scène ***//
    void Update() {
        SearchAllSlots();
        if(SearchAllSlots() == 1) {
            if(slotsPiece.isFull[0] == false && amount_piece > 0) {
                Instantiate(itemPiece, slotsPiece.slots[0].transform, false);
                slotsPiece.isFull[0] = true;
                var p = amount_piece_object.GetComponent<Text>();
                p.text = amount_piece.ToString();
                amount_piece_object.SetActive(true);
            }

            if(slotsPiece.isFull[2] == false && amount_rubis > 0) {
                Instantiate(itemRubis, slotsPiece.slots[2].transform, false);
                slotsPiece.isFull[2] = true;
                var p = amount_rubis_object.GetComponent<Text>();
                p.text = amount_rubis.ToString();
                amount_rubis_object.SetActive(true);
            }

            if(slotsPotion.isFull[0] == false && amount_slot_1 > 0) {
                Instantiate(itemPotion1, slotsPotion.slots[0].transform, false);
                slotsPotion.isFull[0] = true;
                var p = amount_slot_object_1.GetComponent<Text>();
                p.text = amount_slot_1.ToString();
                amount_slot_object_1.SetActive(true);
            }

            if(slotsPotion.isFull[1] == false && amount_slot_2 > 0) {
                Instantiate(itemPotion2, slotsPotion.slots[1].transform, false);
                slotsPotion.isFull[1] = true;
                var p = amount_slot_object_2.GetComponent<Text>();
                p.text = amount_slot_2.ToString();
                amount_slot_object_2.SetActive(true);
            }

            if(slotsPotion.isFull[2] == false && amount_slot_3 > 0) {
                Instantiate(itemPotion3, slotsPotion.slots[2].transform, false);
                slotsPotion.isFull[2] = true;
                var p = amount_slot_object_3.GetComponent<Text>();
                p.text = amount_slot_3.ToString();
                amount_slot_object_3.SetActive(true);
            }

            if(slotsHotbar.isFull[0] == false && amount_slot_hotbar > 0) {
                Instantiate(itemPotionHotbar, slotsHotbar.slots[0].transform, false);
                slotsHotbar.isFull[0] = true;
                var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
                p.text = amount_slot_hotbar.ToString();
                amount_slot_hotbar_hotbar.SetActive(true);
            }
        }
    }
    
    //*** Permet de rechercher tout les slots importants ***//
    private int SearchAllSlots() {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fifth Part");
        foreach(var item in objects) {
            slotsPiece = item.GetComponent<SlotsInventaire>();
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");
        foreach(var item in objects) {
            slotsPotion = item.GetComponent<SlotsInventaire>();
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fourth Part HotBar");
        foreach(var item in objects) {
            slotsHotbar = item.GetComponent<SlotsInventaire>();
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Piece Amount");
        foreach(var item in objects) {
            amount_piece_object = item;
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Rubis Amount");
        foreach(var item in objects) {
            amount_rubis_object = item;
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot 1 Amount");
        foreach(var item in objects) {
            amount_slot_object_1 = item;
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot 2 Amount");
        foreach(var item in objects) {
            amount_slot_object_2 = item;
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot 3 Amount");
        foreach(var item in objects) {
            amount_slot_object_3 = item;
        }
        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "HotBar Potion Amount");
        foreach(var item in objects) {
            amount_slot_hotbar_hotbar = item;
        }
        if(slotsPiece != null && slotsPotion != null && slotsHotbar != null && amount_piece_object != null && amount_rubis_object != null && amount_slot_object_1 != null && amount_slot_object_2 != null && amount_slot_object_3 != null && amount_slot_hotbar_hotbar != null) {
            return 1;
        } else {
            return 0;
        }
    }

    //*** Permet de récupérer le nombre de pièce ***//
    public int GetPiece() {
        return amount_piece;
    }

    //*** Permet de récupérer le nombre de rubis ***//
    public int GetRubis() {
        return amount_rubis;
    }

    //*** Permet de récupérer le nombre de potion dans le slot 1 ***//
    public int GetAmountSlot1() {
        return amount_slot_1;
    }

    //*** Permet de récupérer le nombre de potion dans le slot 2 ***//
    public int GetAmountSlot2() {
        return amount_slot_2;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot1Type() {
        return slot1_type;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot2Type() {
        return slot2_type;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot3Type() {
        return slot3_type;
    }

    //*** Permet de récupérer le type dans la hotbar ***//
    public string GetHotbarType() {
        return hotbar_type;
    }
    
    //*** Permet de récupérer le nombre de potion dans le slot 3 ***//
    public int GetAmountSlot3() {
        return amount_slot_3;
    }

    //*** Permet de récupérer le nombre de potion dans la hotbar ***//
    public int GetAmountHotBar() {
        return amount_slot_hotbar;
    }

    //*** Permet de changer le nombre de potion dans le slot 1 ***//
    public void SetAmountSlot1(int i) {
        amount_slot_1 = amount_slot_1 - i;
    } 

    //*** Permet de changer le nombre de potion dans le slot 2 ***//
    public void SetAmountSlot2(int i) {
        amount_slot_2 = amount_slot_2 - i;
    }

    //*** Permet de changer le nombre de potion dans le slot 3 ***//
    public void SetAmountSlot3(int i) {
        amount_slot_3 = amount_slot_3 - i;
    }

    //*** Permet de changer le nombre de rubis ***//
    public void SetRubis(int x, GameObject item, SlotsInventaire slot) {
        amount_rubis = amount_rubis + x;
        var p = amount_rubis_object.GetComponent<Text>();
        p.text = amount_rubis.ToString();
        if(amount_rubis > 0 && slot.isFull[2] == false) {
            slotsPiece = slot;
            itemRubis = item;
            Instantiate(item, slot.slots[2].transform, false);
            if(slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.name == "rubis_image(Clone)") {
                slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
            }
            amount_rubis_object.SetActive(true);
        } else if(amount_rubis == 0) {
            amount_rubis_object.SetActive(false);
        }
    }

    //*** Permet de changer le nombre de pièce ***//
    public void SetPiece(int x, GameObject item, SlotsInventaire slot) {
        amount_piece = amount_piece + x;
        var p = amount_piece_object.GetComponent<Text>();
        p.text = amount_piece.ToString();
        if(amount_piece > 0 && slot.isFull[0] == false) {
            slotsPiece = slot;
            itemPiece = item;
            Instantiate(item, slot.slots[0].transform, false);
            if(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.name == "coin_image(Clone)") {
                slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
            }
            amount_piece_object.SetActive(true);
        } else if(amount_piece == 0) {
            amount_piece_object.SetActive(false);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 1 ***//
    public void SetPotionSlot1(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_1 = amount_slot_1 + x;
        var p = amount_slot_object_1.GetComponent<Text>();
        p.text = amount_slot_1.ToString();
        if(amount_slot_1 > 0 && slot.isFull[0] == false) {
            itemPotion1 = item;
            Instantiate(itemPotion1, slot.slots[0].transform, false);
            slot.isFull[0] = true;
            amount_slot_object_1.SetActive(true);
        } else if(amount_slot_1 == 0) {
            amount_slot_object_1.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.tag == "HealthPotionInventory") {
            slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 2 ***//
    public void SetPotionSlot2(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_2 = amount_slot_2 + x;
        var p = amount_slot_object_2.GetComponent<Text>();
        p.text = amount_slot_2.ToString();
        if(amount_slot_2 > 0 && slot.isFull[1] == false) {
            itemPotion2 = item;
            Instantiate(itemPotion2, slot.slots[1].transform, false);
            slot.isFull[1] = true;
            amount_slot_object_2.SetActive(true);
        } else if(amount_slot_2 == 0) {
            amount_slot_object_2.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.tag == "ManaPotionInventory") {
            slot.transform.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 3 ***//
    public void SetPotionSlot3(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_3 = amount_slot_3 + x;
        var p = amount_slot_object_3.GetComponent<Text>();
        p.text = amount_slot_3.ToString();
        if(amount_slot_3 > 0 && slot.isFull[2] == false) {
            itemPotion3 = item;
            Instantiate(itemPotion3, slot.slots[2].transform, false);
            slot.isFull[2] = true;
            amount_slot_object_3.SetActive(true);
        } else if(amount_slot_3 == 0) {
            amount_slot_object_3.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DamagePotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DestructPotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "ShieldPotionInventory") {
            slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet de modifier le type présent dans le slot 1 ***//
    public void SetSlot1Type(string name) {
        slot1_type = name;
    }

    //*** Permet de modifier le type présent dans le slot 2 ***//
    public void SetSlot2Type(string name) {
        slot2_type = name;
    }
    
    //*** Permet de modifier le type présent dans le slot 3 ***//
    public void SetSlot3Type(string name) {
        slot3_type = name;
    }

    //*** Permet de modifier le type présent dans la hotbar ***//
    public void SetHotbarType(string name) {
        hotbar_type = name;
    }

    //*** Permet de changer le nombre de potion dans la hotbar ***//
    public void SetHotBarMany(int x, GameObject item = null) {
        amount_slot_hotbar = amount_slot_hotbar + x;
        var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
        p.text = amount_slot_hotbar.ToString();
        if(amount_slot_hotbar >= 1) {
            itemPotionHotbar = item;
            amount_slot_hotbar_hotbar.SetActive(true);
        } else if(amount_slot_hotbar == 0) {
            amount_slot_hotbar_hotbar.SetActive(false);
        }
    }
}
