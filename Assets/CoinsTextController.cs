using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsTextController : MonoBehaviour
{
    private Text text;

    void Start(){
        text=gameObject.GetComponent<Text>();

    }


    void Update(){
        text.text=PlayerPrefs.GetInt("gems").ToString();
    }
}
