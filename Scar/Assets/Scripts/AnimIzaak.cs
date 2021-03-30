using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimIzaak : MonoBehaviour
{
    public Animator izaak;
    
    void Start()
    {
        izaak = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            izaak.SetBool("isRuning", true);
        }
    }
}
