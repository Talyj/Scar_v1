using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;
    
    [SerializeField]
    private  float playerSpeed;

    [SerializeField] 
    private float playerDash;

    [SerializeField] 
    private Rigidbody theRB;
    
    private Vector3 lastDirectionIntent;
    private DashDirection dashDirection;
    
    enum DashDirection
    {
        Left,
        Right,
        Up,
        Down,
        NoDirection
    }

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
        dashDirection = DashDirection.NoDirection;
    }


    // Update is called once per frame
    void Update()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent +=  Vector3.left;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            lastDirectionIntent +=  Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            lastDirectionIntent +=  Vector3.back;
        }
        // Si on lâche la touche on s'arrête
        else
        {
            lastDirectionIntent = Vector3.zero;
        }

        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void Dashing()
    {
        
    }

    private void FixedUpdate()
    {
        playerTransform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
}
