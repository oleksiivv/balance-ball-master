using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGenerator : MonoBehaviour
{
    public Material[] skybox;

    public static int level=-1;
    public static int skyID=0;

    void Start(){
        if(level!=Application.loadedLevel){
            level=Application.loadedLevel;
            if(PlayerPrefs.GetInt("first")!=0){
                skyID=Random.Range(0,skybox.Length);
            }
            else {
                skyID=0;
                PlayerPrefs.SetInt("first",1);
            }
        }
        RenderSettings.skybox=skybox[skyID];
    }

}
