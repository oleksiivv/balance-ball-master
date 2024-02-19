﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class UIMainScene : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;

    public GameObject winPanel;

    public GameObject loadingPanel;

#if UNITY_IOS
    private string appId = "ca-app-pub-4962234576866611~2573814293";
    private string bannerId="ca-app-pub-4962234576866611/1907793407";
    private string intersitionalId="ca-app-pub-4962234576866611/6955912430";
#else
    private string appId = "ca-app-pub-4962234576866611~2573814293";
    private string bannerId="ca-app-pub-4962234576866611/1907793407";
    private string intersitionalId="ca-app-pub-4962234576866611/6955912430";
#endif

    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;

    void Start()
    {
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
          CreateBannerView();
          LoadBannerAd();
          LoadLoadInterstitialAd();
        });
    }

    //baner
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    }

    public void LoadBannerAd()
    {
        // create an instance of a banner view first.
        if(_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    public static int addCnt=0;

    public void pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);

        showIntersitionalGoogleAd();
        
        addCnt++;
    }

    public void resume(){
        Time.timeScale=1;
        pausePanel.SetActive(false);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void win(){
        winPanel.SetActive(true);
    }
    public void nextLevel(){
        openScene((Application.loadedLevel+1));
    }

    public void openScene(int id){
        Time.timeScale=1;
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }

    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }
                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());
                _interstitialAd = ad;
            });
    }


      public bool showIntersitionalGoogleAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }
}
