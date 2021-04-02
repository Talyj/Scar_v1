using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private LymuleHealth BossHealth;
    [SerializeField] private BulletController bullet;
    [SerializeField] private int numBullets;
    public Transform firepoint;
    [SerializeField] private Transform player;
    
    // Derniere Chance
    //[SerializeField] private GameObject pat;
    [SerializeField] private GameObject pot;
    [SerializeField] private GameObject pit;
    private bool premiereChance = true;
    private bool derniereChance = true;
    public bool enervax = true;
    private LymuleHealth currentHealth;
    
    public float bulletSpeed;
    private float radius = -3;
    public static int isAlive = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        //firepoint = GameObject.FindGameObjectWithTag("boss").ge;
        StartCoroutine(SpawnBoss());
    }

    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator SpawnBoss()
    {
        // Tant que le boss est en vie on le fait agir
        while(Boss != null)
        {
            SimpleShoot();
            // Condition actions du boss 75% de vie = spawn petit groupe de monstre 
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.75 && premiereChance)
            {
                SpawnEnemy.Spawn(3, pit);
                SpawnEnemy.Spawn(5, pot);
                premiereChance = false;
                enervax = false;
            }
            // Enervax quand 25% >= BossHealth.currentHealth >= 75%
            if (enervax)
            {
                CircleShoot();
            }
            // 25% de vie = spawn groupe de monstre medium réactive enervax
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.25 && derniereChance)
            {
                enervax = true;
                SpawnEnemy.Spawn(5, pit);
                SpawnEnemy.Spawn(8, pot);
                derniereChance = false;
            }
            yield return new WaitForSeconds(0);
        }
    }

   void SimpleShoot()
    {
        // Vise le player depuis le firepoint
        // Tire sur le player
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - firepoint.position);
        firepoint.rotation = Quaternion.Slerp(firepoint.rotation, targetRotation, 1 * Time.deltaTime);
        BulletController newBullet = Instantiate(bullet, firepoint.position , firepoint.rotation);
        newBullet.speed = bulletSpeed;
    }

    void CircleShoot()
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
