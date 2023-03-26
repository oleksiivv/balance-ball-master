using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    IEnumerator changePos;
    bool isMoving;
    void Start()
    {
        offset=player.transform.position-transform.position;
        isMoving=false;

        changePos=moveTowards(player.transform.position-offset);

        changePos=moveTowards(player.transform.position-new Vector3(offset.x,offset.y,offset.z*3));
        StartCoroutine(changePos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkPlayerMovement();
    }

    
    void checkPlayerMovement(){
        if(!isMoving)transform.position=player.transform.position-offset;
        //  if(player.transform.position.x-transform.position.x>offset.x+35 || player.transform.position.z-transform.position.z>offset.z+35){
            
        //      if(!isMoving){
        //          changePos=moveTowards(player.transform.position-offset);
        //          StartCoroutine(changePos);
        //      }

        //  }
        // if(player.transform.position.z<transform.position.z-3){
        //     if(!isMoving){
        //         changePos=moveTowards(player.transform.position-new Vector3(offset.x,offset.y,offset.z*3));
        //         StartCoroutine(changePos);
        //     }
        // }
    }

    IEnumerator moveTowards(Vector3 pos){
        isMoving=true;
        while(transform.position!=pos){
            transform.position=Vector3.MoveTowards(transform.position,pos,0.1f);
            yield return new WaitForSeconds(0.002f);
        }
        offset=player.transform.position-transform.position;
        isMoving=false;
    }
}
