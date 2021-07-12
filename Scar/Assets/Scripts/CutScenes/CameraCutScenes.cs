using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using UnityEngine;

public class CameraCutScenes : MonoBehaviour
{
    
    private Transform boss;
    private int speedCamera = 6;
    private int distance;


    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        boss = GameObject.FindGameObjectWithTag("boss").transform;
        transform.LookAt(new Vector3(boss.position.x, transform.position.y, boss.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        float dist = Vector3.Distance(boss.transform.position, gameObject.transform.position);
        if (dist <= 10)
        {
            transform.RotateAround(boss.position, Vector3.up, 20 * Time.deltaTime * speedCamera);
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speedCamera;   
        }
    }
    
}
