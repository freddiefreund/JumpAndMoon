using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpVar = 0f;

    private Vector3 moveDir;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(transform.TransformDirection(new Vector3(0, 1000f, 0)));
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);   
    }
}
