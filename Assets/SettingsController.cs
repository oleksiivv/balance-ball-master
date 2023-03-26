using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject buttonMutedSound, buttonNormalSound;
    public Dropdown quality;

    public GameObject loadingBar;
    //public AudioController audio;
    void Start()
    {
        quality.GetComponent<Dropdown>().value=QualitySettings.GetQualityLevel();

        updateSound();
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        updateSound();
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        updateSound();
    }



    void updateSound(){
        if(PlayerPrefs.GetInt("!sound")==0){

            buttonMutedSound.SetActive(false);
            buttonNormalSound.SetActive(true);

        }
        else{
            buttonMutedSound.SetActive(true);
            buttonNormalSound.SetActive(false);
        }

        //audio.updateMusic();
        //audio.updateSound();
    }


    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void openScene(int id){
        Time.timeScale=1;
        loadingBar.SetActive(true);
        Application.LoadLevelAsync(id);
    }

}
