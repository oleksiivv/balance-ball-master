using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
//using GoogleMobileAds.Api;
using Yodo1.MAS;
using System;

public class UIMainScene : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;

    public GameObject winPanel;

    public GameObject loadingPanel;

    private string gameID="4176277";

    private Yodo1U3dBannerAdView bannerAdView;

    void Start(){
        //Advertisement.Initialize(gameID,false);

        //MobileAds.Initialize(appId);
        
        //RequestConfigurationAd();
        //RequestBannerAd();
        InitializeSdk();
        SetPrivacy(true, false, false);
        
        InitializeInterstitialAds();

        Yodo1U3dMas.SetInitializeDelegate((bool success, Yodo1U3dAdError error) => { });
        Yodo1U3dMas.InitializeSdk();

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        // Clean up banner before reusing
        if (bannerAdView != null)
        {
            bannerAdView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner, Yodo1U3dBannerAdPosition.BannerTop | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);
    }

    private void OnInterstitialAdOpenedEvent()
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad opened");
    }

    private void OnInterstitialAdClosedEvent()
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad closed");
    }

    private void OnInterstitialAdErorEvent(Yodo1U3dAdError adError)
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad error - " + adError.ToString());
    }

    private void SetPrivacy(bool gdpr, bool coppa, bool ccpa)
    {
        Yodo1U3dMas.SetGDPR(gdpr);
        Yodo1U3dMas.SetCOPPA(coppa);
        Yodo1U3dMas.SetCCPA(ccpa);
    }

    private void InitializeSdk()
    {
        Yodo1U3dMas.InitializeSdk();
    }

    private void InitializeInterstitialAds()
    {
        Yodo1U3dMasCallback.Interstitial.OnAdOpenedEvent +=    
        OnInterstitialAdOpenedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdClosedEvent +=      
        OnInterstitialAdClosedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdErrorEvent +=      
        OnInterstitialAdErorEvent;
    }

    public static int addCnt=0;

    public void pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);

            // if(Advertisement.IsReady("video")){
            //     Advertisement.Show("video");
            // }
            // else{
            //     showIntersitionalAd();
            // }
            if(Yodo1U3dMas.IsInterstitialAdLoaded()){
                Yodo1U3dMas.ShowInterstitialAd();
            }
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
        //StopAllCoroutines();
        openScene((Application.loadedLevel+1));
    }

    public void openScene(int id){
        Time.timeScale=1;
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }






    /*
    private InterstitialAd intersitional;
    private BannerView banner;

    private string appId="ca-app-pub-4962234576866611~2573814293";
    private string intersitionalId="ca-app-pub-4962234576866611/6955912430";

    private string bannerId="ca-app-pub-4962234576866611/1907793407";
    
     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);
          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

    }


      public void showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();
          }
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

          //RequestConfigurationAd();

        
      }

     private void HandleOnAdOpening(object sender, EventArgs e)
     {
        
     }

     private void HandleOnAdLoaded(object sender, EventArgs e)
     {
        
     }

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }




    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Top);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }

    */
}
