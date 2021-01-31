using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] grosMobz;
    public GameObject[] ptitsMobz;

    private bool LMB;
    public float spawnTimer, spawningTime;
    public float speed;
    public bool spawned;

    public GameObject[] spawnPoint, wayPoint;
    public GameObject player;

    public State state;
    private bool spawning;

    public enum State
    {
        Vague1,
        Vague2,
        Vague3,
        NoVague
    }

    void Start()
    {
        spawned = false;
        spawnTimer = 0;
        state = State.Vague1;
        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint").OrderBy((gameObject) => { return gameObject.name; }).ToArray();
        wayPoint = GameObject.FindGameObjectsWithTag("WayPoint").OrderBy((gameObject) => { return gameObject.name; }).ToArray();

        spawning = true;
        StartCoroutine(SpawnCoroutine());
    }


    void Update()
    {
  
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1);
        yield return SpawnPattern(0, 1, 3, 1);

        yield return new WaitForSeconds(9); 
        yield return SpawnPattern(1, 2, 4, 1);

        yield return new WaitForSeconds(16); 
        yield return SpawnPattern(2, 3, 2, 1);

        yield return new WaitForSeconds(21); 
        yield return SpawnPattern(0, 1, 3, 1);
        yield return SpawnPattern(1, 2, 4, 1);

        yield return new WaitForSeconds(30);
        yield return SpawnPattern(0, 1, 3, 1);
        yield return SpawnPattern(2, 2, 4, 1);

        yield return new WaitForSeconds(39);
        yield return SpawnPattern(1, 2, 4, 1);
        yield return SpawnPattern(2, 3, 2, 1);

        yield return new WaitForSeconds(30);
        yield return SpawnPattern(0, 1, 3, 1);
        yield return SpawnPattern(1, 2, 4, 1);
        yield return SpawnPattern(2, 3, 2, 1);

    }

    IEnumerator SpawnPattern(int spawnIndex, int numGros, int numPtits, float speed)
    {
        Debug.Log("PATTERN " + (spawnIndex + 1));

        var selectedSpawn = spawnPoint[spawnIndex];

        for (var i = 0; i < numGros; i++)
        {
            var selectedGrosMob = grosMobz[0];

            var randomCircle = Random.onUnitSphere;
            randomCircle.z = 0;

            var clone = Instantiate(selectedGrosMob, selectedSpawn.transform.position, selectedSpawn.transform.rotation);
            clone.GetComponent<waypoints>().wayPoint = new[] { wayPoint[spawnIndex], player };
            clone.GetComponent<waypoints>().speed = speed;

            yield return new WaitForSeconds(1.5f);
        }

        for (var i = 0; i < numPtits; i++)
        {
            var mob = ptitsMobz[0];

            var randomCircle = Random.onUnitSphere;
            randomCircle.z = 0;

            var clone = Instantiate(mob, selectedSpawn.transform.position, selectedSpawn.transform.rotation);
            clone.GetComponent<waypoints>().wayPoint = new[] { wayPoint[spawnIndex], player};
            clone.GetComponent<waypoints>().speed = speed;

            yield return new WaitForSeconds(1.5f);
        }
    }
}
