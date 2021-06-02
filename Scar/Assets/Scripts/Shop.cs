using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Animator cam;
    public GameObject shop;
    public GameObject inventaire;

    AmountBoard money;
    void Start()
    {
        money = GetComponent<AmountBoard>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.Play("ShopCamera", -1, 0f);
            shop.SetActive(true);
            inventaire.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.Play("ShopCameraOut", -1, 0f);
            shop.SetActive(false);
            inventaire.SetActive(false);
        }
    }

    public void Health()
    {
        if (money.amount_piece >= 50)
        {
            money.amount_piece -= 50;
        }
    }

    public void Mana()
    {
        if (money.amount_piece >= 65)
        {
            money.amount_piece -= 65;
        }
    }

    public void ShieldUp()
    {
        if (money.amount_piece >= 400)
        {
            money.amount_piece -= 400;
        }
    }

    public void AttackUp()
    {
        if (money.amount_piece >= 300)
        {
            money.amount_piece -= 300;
        }
    }

    public void DeleteBullet()
    {
        if (money.amount_piece >= 500)
        {
            money.amount_piece -= 500;
        }
    }

   
}
