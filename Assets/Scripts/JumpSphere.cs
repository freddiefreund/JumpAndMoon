using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSphere : MonoBehaviour
{
    public bool isOnGround;
    // Start is called before the first frame update
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
