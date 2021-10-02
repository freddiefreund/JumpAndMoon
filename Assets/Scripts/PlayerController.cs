﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpVar = 0f;

    private Vector3 _moveDir;
    Rigidbody _rb;
    JumpSphere _jumpSphere;
    bool _shouldJump;

    float _timestamp;
    float _jumpperiod = 0.2f;
    float _lastjump;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lastjump = Time.time;
        _jumpSphere = GetComponentInChildren<JumpSphere>();
    }

    void Update()
    {
        _moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _timestamp = Time.time + _jumpperiod;
            _shouldJump = true;
        }
    }

    void FixedUpdate() {
        if (_shouldJump)
        {
            float timesinceJump = Time.time - _lastjump;
            if (Time.time < _jumpSphere.timestamp || (_jumpSphere.isOnGround && Time.time < _timestamp))
            {
                Debug.Log(timesinceJump);
                if (timesinceJump > 0.25f)
                {
                    _lastjump = Time.time;
                    _shouldJump = false;
                    _rb.AddForce(transform.TransformDirection(new Vector3(0, 1000f, 0)));
                }
            }
        }
        _rb.MovePosition(_rb.position + transform.TransformDirection(_moveDir) * moveSpeed * Time.deltaTime);   
    }
}
