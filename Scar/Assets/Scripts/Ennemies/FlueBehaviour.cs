using System.Collections;
using UnityEngine;

public class FlueBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private FlueHealth BossHealth;
    private Transform player;
    
    // Derniere Chance
    [SerializeField] private GameObject pat;
    [SerializeField] private GameObject put;
    private bool premiereChance = true;
    private bool derniereChance = true;
    private FlueHealth currentHealth;
    
    public static int isAlive = 1;
    
    //Cooldown attaques basiques
    private float hitCounter; 
    /*[SerializeField] private Transform[] hitPoints;
    [SerializeField] private Transform BasePoint;*/
    
    //Deplacement du boss pour la charge
    [SerializeField] private float defaultSpeedMonster;
    private float speed;

    //Attaques Bobb
    [SerializeField] private AttackTentacule TentaculeDeMort;
    
    //Attaque Lymule
    [SerializeField] private BulletController bullet;
    private int numBullets = 50;
    private float radius = -3;
    private float bulletSpeed = 25;


    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeedMonster;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossBehaviour());
    }

    private void Update()
    {
        Deplacement();
    }

    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator BossBehaviour()
    {
        // Tant que le boss est en vie on le fait agir
        while(Boss != null)
        {
            // Attaque en cas de distance élevé avec le joueur
            CircleShoot();
            hitCounter -= Time.deltaTime;
            if (hitCounter <= 0)
            {
                // Attaque avec delai de base
                //Ratatatata();
                hitCounter = Random.Range(5, 20);
            }
            else
            {
                hitCounter = 0;
            }
            
            // Condition actions du boss 75% de vie = spawn petit groupe de monstre 
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.75 && premiereChance)
            {
                SpawnEnemy.Spawn(3, put);
                SpawnEnemy.Spawn(5, pat);
                premiereChance = false;
            }
            // 25% de vie = spawn groupe de monstre medium
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.25 && derniereChance)
            {
                SpawnEnemy.Spawn(5, put);
                SpawnEnemy.Spawn(8, pat);
                derniereChance = false;
            }
            yield return new WaitForSeconds(1);
        }
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

    private void Ratatatata()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist >= 30)
        {
            var nbTentacule = Random.Range(10, 20);
            for (int i = 0; i < nbTentacule; i++)
            {
                var xPos = player.position.x + Random.Range(-20, 20);
                var zPos = player.position.z + Random.Range(-20, 20);
                
                AttackTentacule newTentacule = Instantiate(TentaculeDeMort,
                    new Vector3(xPos, player.position.y + 20, zPos),
                    player.rotation) as AttackTentacule;
            }
        }
    }

    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
        
        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
}
