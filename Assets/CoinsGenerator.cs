using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public Vector3 topLeft, bottomRight;

    public GameObject coinsPrephab;
    




    void Start(){

        for(int i=0;i<Application.loadedLevel*2/5+5;i++){
            Instantiate(coinsPrephab, new Vector3(Random.Range(topLeft.x, bottomRight.x),coinsPrephab.transform.position.y,Random.Range(bottomRight.z,topLeft.z)),coinsPrephab.transform.rotation);
        }
    }
}
