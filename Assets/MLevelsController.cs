using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MLevelsController : MonoBehaviour
{
    public Color32 activeLevelColor, closedLevelColor;
    public Image[] levels;
    public GameObject loadingPanel;

    void Start()
    {
        for(int i=1;i<levels.Length;i++){
            if(PlayerPrefs.GetInt("winAt"+i.ToString())==1 || PlayerPrefs.GetInt("winAt"+(i+1).ToString())==1){
                levels[i].GetComponent<Image>().color=activeLevelColor;
            }
            else{
                levels[i].GetComponent<Image>().color=closedLevelColor;
            }
        }
    }

    public void openLevel(int id){
        if(PlayerPrefs.GetInt("winAt"+(id-1).ToString())==1 || id==1){
            Time.timeScale=1;
            loadingPanel.SetActive(true);
            Application.LoadLevelAsync(id);
        }
        
    }
}
