using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMenu : MonoBehaviour
{
    public GameObject levelsPanel;
    public GameObject loadingPanel;

    public void showLevelsPanel(){
        levelsPanel.SetActive(true);
    }

    public void closeLevelsPanel(){
        levelsPanel.SetActive(false);
    }
    public void openScene(int id){
        Time.timeScale=1;
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }
}
