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
    }


    // Update is called once per frame
    void Update()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent +=  Vector3.left;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            lastDirectionIntent +=  Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            lastDirectionIntent +=  Vector3.back;
        }
        if (!Input.anyKey)
        {
            // Si on lâche la touche on s'arrête
            lastDirectionIntent = Vector3.zero;
        }
        Dashing();

        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void Dashing()
    {
        if (Input.GetMouseButton(1))
        {
            float dashDistance = 0.5f;
            playerTransform.position += lastDirectionIntent * dashDistance;
        }
    }

    private void FixedUpdate()
    {
        playerTransform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
}
