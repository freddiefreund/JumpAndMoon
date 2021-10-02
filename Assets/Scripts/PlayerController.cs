using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpVar = 0f;

    private Vector3 moveDir;

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),jumpVar,Input.GetAxisRaw("Vertical")).normalized;
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpVar = 1f;
        }else if(!Input.GetKeyDown(KeyCode.Space) && jumpVar > 0f){
            jumpVar -= 1.5f* Time.deltaTime;
        }
        if(jumpVar < 0.1f)
            jumpVar = 0;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);   
    }
}
