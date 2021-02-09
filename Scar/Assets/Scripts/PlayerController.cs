using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;
    [SerializeField] private  float playerSpeed;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GunController theGun;
    [SerializeField] private float timeBetweenDash;
    
    //Statistiques
    public static int numberBullets = 0;
    public static int numberDamagesReceived = 0;
    public static int numberDamagesDealt = 0;
    public static int score = 0;

    //Movement and Dash variables
    private Vector3 lastDirectionIntent;
    private float dashCounter;


    private void Start()
    {
    }

    private void FixedUpdate()
    {
        playerTransform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
    
    void Update()
    {
        Movement();
        View();
        Dashing();
        Firing();



        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void Dashing()
    {
        if (Input.GetMouseButton(1))
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                dashCounter = timeBetweenDash;
                float dashDistance = 1;
                playerTransform.position += lastDirectionIntent * dashDistance;
            }
        }
        else
        {
            dashCounter = 0;
        }
    }

    private void Firing()
    {
        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }

    private void View()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            
            playerTransform.LookAt(new Vector3(pointToLook.x, playerTransform.position.y, pointToLook.z));
        }
    }

    private void Movement()
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
    }
}
