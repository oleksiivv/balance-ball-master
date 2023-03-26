using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;

    void Start(){
        if(PlayerPrefs.GetInt("!sound")==0){
            
            source.clip=clips[Random.Range(0,clips.Length)];
            source.enabled=true;
            source.Play();
        }
        else{
            source.enabled=false;
        }

        
    }
}
