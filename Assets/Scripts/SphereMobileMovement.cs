using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMobileMovement : MonoBehaviour
{
    public Joystick joystick;

    private Rigidbody rigidbody;

    public int speed=1;

    void Start(){
        rigidbody=gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        // if(joystick.Vertical!=0 && joystick.Horizontal!=0){

        //     float heading = Mathf.Atan2(joystick.Horizontal,joystick.Vertical);
        //     transform.rotation=Quaternion.Euler(0f,heading*Mathf.Rad2Deg,0f);
            
        //     rigidbody.AddForce(Vector3.forward/-5);
        // }
        if(joystick.Vertical!=0 || joystick.Horizontal!=0){
            //rigidbody.velocity = Vector3.right*-joystick.Horizontal*speed*Time.timeScale;
            //rigidbody.velocity = Vector3.forward*-joystick.Vertical*speed*Time.timeScale;
            //rigidbody.angularVelocity = rigidbody.angularVelocity * 0.99f;

            //OLD
            rigidbody.AddForce(Vector3.right*-joystick.Horizontal*speed*Time.timeScale,ForceMode.Force);  
            rigidbody.AddForce(Vector3.forward*-joystick.Vertical*speed*Time.timeScale,ForceMode.Force); 

            //gameObject.transform.Translate(Vector3.forward*-joystick.Vertical*speed*Time.deltaTime);
            //gameObject.transform.Translate(Vector3.right*-joystick.Horizontal*speed*Time.deltaTime);
        }
        else{
            rigidbody.velocity = rigidbody.velocity * 0.9f;
            //rigidbody.angularVelocity = rigidbody.angularVelocity * 0.99f;
        }
    }
}
