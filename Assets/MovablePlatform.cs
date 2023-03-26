using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public Vector3 pointsFrom;
    public Vector3 pointsTo;

    public float delay;
    private int dir=1;

    public bool onlyY=false;
    void Start(){
        if(!onlyY)transform.position=pointsFrom;
        else transform.position = new Vector3(transform.position.x,pointsFrom.y,transform.position.z);
        StartCoroutine(move());
    }

    void Update(){
        if(dir==1){
            if(!onlyY){
                transform.position=Vector3.MoveTowards(transform.position,pointsTo,delay/100*Time.timeScale);
            }
            else{
                transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,pointsTo.y,transform.position.z),delay/100*Time.timeScale);
            }
        }
        else{
            if(!onlyY){
                transform.position=Vector3.MoveTowards(transform.position,pointsFrom,delay/100*Time.timeScale);
            }
            else{
                 transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,pointsFrom.y,transform.position.z),delay/100*Time.timeScale);
            }
        }
    }

    IEnumerator move(){
        while(true){


            yield return new WaitForSeconds(delay);
            dir*=-1;
        }
    }
}
