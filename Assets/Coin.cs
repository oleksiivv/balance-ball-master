using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody rigidbody;
    private ParticleSystem particle;
    void Start(){
        particle=gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        rigidbody=gameObject.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToUpper().Contains("PLAYER")){
            PlayerPrefs.SetInt("gems", PlayerPrefs.GetInt("gems")+1);
            particle.Play();
            gameObject.GetComponent<BoxCollider>().isTrigger=true;
            gameObject.GetComponent<MeshRenderer>().enabled=false;
            Invoke(nameof(clean),1);
        }
        else{
            rigidbody.isKinematic=true;
        }
    }

    void clean(){
        Destroy(gameObject);
    }
}
