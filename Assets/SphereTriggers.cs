using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class SphereTriggers : MonoBehaviour
{
    public UIMainScene ui;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToUpper()=="DEATH"){
            ui.deathPanel.SetActive(true);

            if(UIMainScene.addCnt%2==1){
                ui.showIntersitionalGoogleAd();
            }
            UIMainScene.addCnt++;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToUpper()=="MOVABLEPLATFORM"){
            //transform.parent = other.gameObject.transform;
            //SphereMobileMovement.movable=false;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag.ToUpper()=="MOVABLEPLATFORM"){
            //transform.parent = null;
            //SphereMobileMovement.movable=false;
        }
    }
}
