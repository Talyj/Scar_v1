using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 cameraOffset;
    
    void Start()
    {
        cameraOffset = transform.position - playerTransform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
