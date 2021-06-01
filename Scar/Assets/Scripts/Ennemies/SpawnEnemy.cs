using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject pot;
    public  GameObject pat;
    public GameObject put;
    public GameObject pit;
    public  GameObject boss;
    public GameObject miniBoss;
    public GameObject spawnMonster;
    private static float xPos;
    private static float zPos;

    private int numPot;
    private  int numPat;
    private int numPut;
    private int numPit;
    
    private int cptWave;
    private int monstreRecup;
    public int numBoss;
    public int numMiniBoss;
    
    public static int nbMonster;
    
    private GameObject door;
    private GameObject spawnPoint;

    private GameObject[] portes;

    private static Transform player;

    public bool hasEnded;
    public static bool open;

    void Start()
    {

        hasEnded = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (numMiniBoss > 0 || numBoss > 0)
        {
            cptWave = 1;
            monstreRecup = 0;
        }
        else
        {
            cptWave = Random.Range(1, 4);
            if (SceneManager.GetActiveScene().name == "Main")
            {
                monstreRecup = Random.Range(1, 2);
            }
            else if (SceneManager.GetActiveScene().name == "Donjon2")
            {
                monstreRecup = Random.Range(2, 3);
            }
            else if (SceneManager.GetActiveScene().name == "Donjon3")
            {
                monstreRecup = Random.Range(3, 4);
            }
            else if (SceneManager.GetActiveScene().name == "Donjon4")
            {
                monstreRecup = Random.Range(4, 5);
            }
        }
        
    }

    private void Update()
    {
        spawnPoint = spawnMonster;
        
        xPos = Random.Range(spawnPoint.transform.position.x - 15, spawnPoint.transform.position.x) + 15;
        zPos = Random.Range(spawnPoint.transform.position.z - 15, spawnPoint.transform.position.z + 15);
        
        if (nbMonster <= 0 && cptWave > 0)
        {
            SpawnMonster(monstreRecup);
            cptWave -= 1;
        }
        
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        portes = GameObject.FindGameObjectsWithTag("BloquePorte");
        if (nbMonster <= 0 && cptWave <= 0)
        if(enemies.Length <= 0 && cptWave <= 0 && hasEnded == false)
        {
            foreach (var gameobject in portes)
            
            gameobject.GetComponent<Animator>().Play("OuverturePorteDonjon", -1, 0f);
            
            hasEnded = true;
        }
    }

    public static void Spawn(int numSpawn, GameObject typeMonster)
    {
        for (int i = 0; i < numSpawn; i++)
        {
            xPos = Random.Range(xPos - 10, xPos + 10);
            zPos = Random.Range(zPos - 10, zPos + 10);
            Instantiate(typeMonster, new Vector3(xPos, player.transform.position.y + 2, zPos), Quaternion.identity);
            nbMonster += 1;
        }
    }

    private void SpawnMonster(int sizeGroup)
    {
        {
            if (sizeGroup > 0 && nbMonster <= 1)
            {
                numPot = Random.Range(1, monstreRecup);
                numPat = Random.Range(2, monstreRecup * 2);
                numPut = Random.Range(3, monstreRecup * 3);
                numPit = Random.Range(0, monstreRecup);
                for (var i = 0; i < monstreRecup; i++)
                {
                    Spawn(numPot, pot);
                    Spawn(numPat, pat);
                    Spawn(numPut, put);
                    Spawn(numPit, pit);
                    sizeGroup -= 1;
                }
            }
            if (sizeGroup == 0)
            {
                if (numBoss > 0)
                {
                    Spawn(numBoss, boss);
                    numBoss -= 1;
                }

                if (numMiniBoss > 0)
                {
                    Spawn(numMiniBoss, miniBoss);
                    numMiniBoss -= 1;
                }
                
                
            }
        }
    }
}
