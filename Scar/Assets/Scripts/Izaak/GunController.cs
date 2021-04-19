using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    public static float timeBetweenShots;
    
    public bool isFiring;
    private float shotCounter;

    private void Start()
    {
        timeBetweenShots = 0.2f;
        //timeBetweenShots = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                PlayerController.numberBullets += 1;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
