using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private BulletController bullet;
    [SerializeField] private int numBullets;
    private int elementGenereCount = 0;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform player;
    public float bulletSpeed;
    private int xPos;
    private int zPos;
    private float radius = 3;



    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 1; i < 100000; i++)
        {
            SimpleShoot();
            //TODO AJOUTER CONDITION DE WALL
            CircleShoot();
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SimpleShoot()
    {
        BulletController newBullet = Instantiate(bullet, firepoint.position , firepoint.rotation);
        newBullet.speed = bulletSpeed;
    }

    void CircleShoot()
    {
        for (int i = 0; i < numBullets; i++)
        {
            BulletController newBullet = Instantiate(bullet, Boss.transform.position + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
            newBullet.speed = bulletSpeed;
            newBullet.transform.RotateAround(Boss.transform.position, Vector3.up, 360/(float)numBullets*i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - firepoint.position);
        firepoint.rotation = Quaternion.Slerp(firepoint.rotation, targetRotation, 1 * Time.deltaTime);
    }
}
