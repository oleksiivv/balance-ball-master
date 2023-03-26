using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb;

    void Start(){
        rb=gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other){
        Invoke(nameof(useGravity),0.75f);
    }

    void useGravity(){
        rb.useGravity=true;
        rb.isKinematic=false;
    }
}
