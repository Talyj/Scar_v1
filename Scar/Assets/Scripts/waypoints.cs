using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour { 

    public int current = 0;
    public float speed;
    public GameObject target;

    public GameObject[] wayPoint;

    void Update()
    {
        var currentWaypoint = wayPoint[current];
        var delta = (currentWaypoint.transform.position - transform.position);
        var direction = delta.normalized;

        transform.Translate(direction * Time.deltaTime * speed);

        if (delta.sqrMagnitude < 0.1 && current < (wayPoint.Length - 1))
        {
            current++;
        }
    }
          
}

