using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private AttackZoneController hittingZone;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private Transform weapon;


    public bool isFighting;
    private float hitCounter;
    private Collider colliderHittingZone;
    
    // Start is called before the first frame update
    private void Start()
    {
        //colliderHittingZone = hittingZone.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFighting)
        {
            hitCounter -= Time.deltaTime;
            if (hitCounter <= 0)
            {
                hitCounter = timeBetweenHits;
                AttackZoneController newZone = Instantiate(hittingZone, weapon.position + new Vector3(0.5f, 0, 2), weapon.rotation) as AttackZoneController;
                PlayerController.numberBullets += 1;
            }
        }
        else
        {
            hitCounter = 0;
        }
    }
}
