using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSphere : MonoBehaviour
{
    public bool isOnGround;
    public float timestamp;
    float jumpperiod = 0.2f;
    
    void Start()
    {
        timestamp = Time.time + jumpperiod;
        isOnGround = false;
    }

    void OnTriggerExit(Collider other)
    {
        timestamp = Time.time + jumpperiod;
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
