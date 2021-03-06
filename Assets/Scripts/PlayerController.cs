using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BubblePopUp bubble;
    public float jumpForce = 1000;
    public float rotationSpeed = 4;
    public float movementSpeed = 8;
    public float airSpeedMultiplier = 0.7f;

    private Vector3 _moveDir;
    Rigidbody _rb;
    JumpSphere _jumpSphere;
    bool _shouldJump;

    [SerializeField]
    private float vAxis;
    [SerializeField]
    private float hAxis;
    private bool isGrounded;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _timestamp = Time.time + _jumpperiod;
            _shouldJump = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("finish");
        }
    }

    void FixedUpdate()
    {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");
        isGrounded = _jumpSphere.isOnGround;

        anim.SetFloat("movement", vAxis);
        _moveDir = transform.forward * vAxis;
        if(!isGrounded)
            _moveDir *= airSpeedMultiplier;
        else
            anim.SetTrigger("jumpstop");
        
        _rb.AddForce(_moveDir * movementSpeed);
        
        if (_shouldJump)
        {
            float timesinceJump = Time.time - _lastjump;
            if (Time.time < _jumpSphere.timestamp || (_jumpSphere.isOnGround && Time.time < _timestamp))
            {
                Debug.Log(timesinceJump);
                if (timesinceJump > 0.25f)
                {
                    anim.SetTrigger("jumpstart");
                    _lastjump = Time.time;
                    _shouldJump = false;
                    _rb.AddForce(transform.TransformDirection(new Vector3(0, jumpForce, 0)),ForceMode.Impulse);
                }
            }
        }

        if (vAxis >= 0)
        {
            transform.Rotate(new Vector3(0, hAxis * rotationSpeed, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            PlatformOpacity script = other.GetComponent<PlatformOpacity>();
            if (!script.wasHitBefore)
            {
                bubble.PopUp();
            }
            script.hit();
        }
    }
}
