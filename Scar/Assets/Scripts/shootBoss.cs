using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private BulletController bullet;
    [SerializeField] private int numBullets;
    public  Transform firepoint;
    [SerializeField] private Transform player;
    
    public float bulletSpeed;
    private float radius = -3;
    // Start is called before the first frame update
    public void SimpleShoot()
    {
        // Vise le player depuis le firepoint
        // Tire sur le player
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - firepoint.position);
        firepoint.rotation = Quaternion.Slerp(firepoint.rotation, targetRotation, 1 * Time.deltaTime);
        BulletController newBullet = Instantiate(bullet, firepoint.position , firepoint.rotation);
        newBullet.speed = bulletSpeed;
    }

    public void CircleShoot()
    {
        // spawn les balles en cercle autour du boss
        for (int i = 0; i < numBullets; i++)
        {
            // Determine la position de spawn des balles
            BulletController newBullet = Instantiate(bullet, Boss.transform.position + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
            newBullet.speed = bulletSpeed;
            // Modifie la manière de spawn des balles (ici en cercle)
            newBullet.transform.RotateAround(Boss.transform.position, Vector3.up, 360/(float)numBullets*i);
        }
    }
}
