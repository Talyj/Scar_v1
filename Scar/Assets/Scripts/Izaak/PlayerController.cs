using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private  float playerSpeed;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GunController theGun;
    [SerializeField] private WeaponController theWeapon;
    [SerializeField] private Rigidbody playerRigidbody;
    
    //Statistiques
    public static int numberBullets = 0;
    public static float numberDamagesReceived = 0;
    public static float numberDamagesDealt = 0;
    public static int score = 0;
    private static bool ArmeAuCaC = false;
    
    //variable save
    public static bool lymuleDead;
    public static bool korinhDead;
    public static bool bobbDead;
    public static bool flueDead;

    //Movement and Dash variables
    private Vector3 lastDirectionIntent;
    private float dashCounter;
    private float dashDistance = 100000;


    public static int cpt;
    
    private void Awake()
    {
        string destination = Application.persistentDataPath + "/game.dat";
        if (File.Exists(destination))
        {
            var sr = File.ReadLines(destination);
            foreach (var line in sr)
            {
                GunController.timeBetweenShots = float.Parse(line);
                Debug.Log(line);
            }
        }
        numberBullets = 0;
        numberDamagesReceived = 0;
        numberDamagesDealt = 0;
        score = 0;
        SpawnEnemy.nbMonster = 0;
        BossBehaviour.isAlive = 1;
        cpt = 0;
        lymuleDead = false;
        korinhDead = false;
        bobbDead = false;
        flueDead = false;
    }

    private void Start()
    {
        Time.timeScale = 1f;
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
        if (ArmeAuCaC)
        {
            Hitting();
        }
        else
        {
            Firing();    
        }

        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void Dashing()
    {
        dashCounter -= Time.deltaTime;
        if (dashCounter <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                dashCounter = 2;
                if (Input.GetKey(KeyCode.D))
                {
                    playerRigidbody.AddForce(Vector3.right * dashDistance);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    playerRigidbody.AddForce(Vector3.left * dashDistance);
                }
                if (Input.GetKey(KeyCode.Z))
                {
                    playerRigidbody.AddForce(Vector3.forward * dashDistance);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    playerRigidbody.AddForce(Vector3.back * dashDistance);
                }
            }
        }
    }

    private void Firing()
    {
        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }

    private void Hitting()
    {
        if (Input.GetMouseButtonDown(0))
            theWeapon.isFighting = true;

        if (Input.GetMouseButtonUp(0))
            theWeapon.isFighting = false;
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
