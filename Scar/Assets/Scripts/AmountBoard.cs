using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AmountBoard : MonoBehaviour {

    public int amount_piece = 0;
    public int amount_rubis = 0;
    public int amount_slot_1 = 0;
    public int amount_slot_2 = 0;
    public int amount_slot_3 = 0;
    public static int amount_slot_hotbar = 0;
    public GameObject amount_piece_object;
    public GameObject amount_rubis_object;
    public GameObject amount_slot_object_1;
    public GameObject amount_slot_object_2;
    public GameObject amount_slot_object_3;
    public GameObject amount_slot_hotbar_hotbar;

    public int GetPiece() {
        return amount_piece;
    }

    public int GetRubis() {
        return amount_rubis;
    }

    public int GetAmountSlot1() {
        return amount_slot_1;
    }

    public int GetAmountSlot2() {
        return amount_slot_2;
    }

    public int GetAmountSlot3() {
        return amount_slot_3;
    }

    public int GetAmountHotBar() {
        return amount_slot_hotbar;
    }

    public int GetPotion(int x) {
        if(x == 0) {
            return GetAmountSlot3();
        } else if(x == 1) {
            return GetAmountSlot2();
        } else if(x == 2) {
            return GetAmountSlot1();
        } else {
            return 0;
        }
    }

    public void SetRubis(int x) {
        amount_rubis = amount_rubis + x;
        var p = amount_rubis_object.GetComponent<Text>();
        p.text = amount_rubis.ToString();
        if(amount_rubis == 1) {
            amount_rubis_object.SetActive(true);
        } else if(amount_rubis == 0) {
            amount_rubis_object.SetActive(false);
        }
    }

    public void SetHotBarMany(int x) {
        amount_slot_hotbar = amount_slot_hotbar + x;
        var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
        p.text = amount_slot_hotbar.ToString();
        if(amount_slot_hotbar >= 1) {
            amount_slot_hotbar_hotbar.SetActive(true);
        } else if(amount_slot_hotbar == 0) {
            amount_slot_hotbar_hotbar.SetActive(false);
        }
    }

    public void SetPiece(int x) {
        amount_piece = amount_piece + x;
        var p = amount_piece_object.GetComponent<Text>();
        p.text = amount_piece.ToString();
        if(amount_piece == 1) {
            amount_piece_object.SetActive(true);
        } else if(amount_piece == 0) {
            amount_piece_object.SetActive(false);
        }
    }

    public void SetPotion(int x, int y) {
        if(x == 0) {
            SetPotionSlot3(y);
        } else if(x == 1) {
            SetPotionSlot2(y);
        } else if(x == 2) {
            SetPotionSlot1(y);
        }
    }

    public void SetPotionSlot1(int x) {
        amount_slot_1 = amount_slot_1 + x;
        var p = amount_slot_object_1.GetComponent<Text>();
        p.text = amount_slot_1.ToString();
        if(amount_slot_1 == 1) {
            amount_slot_object_1.SetActive(true);
        } else if(amount_slot_1 == 0) {
            amount_slot_object_1.SetActive(false);
        }
    }

    public void SetPotionSlot2(int x) {
        amount_slot_2 = amount_slot_2 + x;
        var p = amount_slot_object_2.GetComponent<Text>();
        p.text = amount_slot_2.ToString();
        if(amount_slot_2 == 1) {
            amount_slot_object_2.SetActive(true);
        } else if(amount_slot_2 == 0) {
            amount_slot_object_2.SetActive(false);
        }
    }

    public void SetPotionSlot3(int x) {
        amount_slot_3 = amount_slot_3 + x;
        var p = amount_slot_object_3.GetComponent<Text>();
        p.text = amount_slot_3.ToString();
        if(amount_slot_3 == 1) {
            amount_slot_object_3.SetActive(true);
        } else if(amount_slot_3 == 0) {
            amount_slot_object_3.SetActive(false);
        }
    }
}
