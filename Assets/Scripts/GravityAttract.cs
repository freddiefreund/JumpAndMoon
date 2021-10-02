using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttract : MonoBehaviour
{
    void Start()
    {
        myTransform = transform;
    }

    public float gravity = -10f;
    private Transform myTransform;
    public void attract(Transform body){
        Vector3 gravityUp = (body.position - myTransform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp,gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation,targetRotation, 50 * Time.deltaTime);
    }
}
