using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSphere : MonoBehaviour
{
    public bool isOnGround;
    
    void Start()
    {
        isOnGround = false;
    }

    void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (! other.CompareTag("Player"))
        {
            isOnGround = true;
        }
    }
}
