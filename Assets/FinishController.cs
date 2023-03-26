using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public ParticleSystem winEffect;
    public UIMainScene ui;

    void Start(){
        if(winEffect==null)winEffect=gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToUpper()=="PLAYER"){
            PlayerPrefs.SetInt("winAt"+Application.loadedLevel.ToString(),1);
            winEffect.Play();
            ui.win();
        }
    }
}
