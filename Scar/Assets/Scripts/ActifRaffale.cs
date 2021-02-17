using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActifRaffale : MonoBehaviour
{
    [SerializeField] private int numBullets;
    [SerializeField] private BulletController bullet;
    public float bulletSpeed;
    private float radius = 1;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Actif"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CircleShoot();
                PlayerController.numberBullets += numBullets;
            }
        }
     
    }

    void CircleShoot()
    {
        for (int i = 0; i < numBullets; i++)
        {
            // Determine la position de spawn des balles
            BulletController newBullet = Instantiate(bullet, gameObject.transform.position + Vector3.up * radius, new Quaternion(0, 0, 0, 0)) as BulletController;
            newBullet.speed = bulletSpeed;
            // Modifie la manière de spawn des balles (ici en cercle)
            newBullet.transform.RotateAround(gameObject.transform.position, Vector3.up, 360 / (float)numBullets * i);
        }
    }
}
