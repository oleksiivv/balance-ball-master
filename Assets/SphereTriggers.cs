using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using GoogleMobileAds.Api;
using Yodo1.MAS;
using System;

public class SphereTriggers : MonoBehaviour
{
    public UIMainScene ui;

    private string gameID="4176277";

    void Start(){
        //Advertisement.Initialize(gameID,false);

        //MobileAds.Initialize(appId);
        //RequestConfigurationAd();
        InitializeSdk();
        SetPrivacy(true, false, false);
        
        InitializeInterstitialAds();

        Yodo1U3dMas.InitializeSdk();
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


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToUpper()=="DEATH"){
            ui.deathPanel.SetActive(true);

            if(UIMainScene.addCnt%2==1){
                // if(Advertisement.IsReady("video")){
                //     Advertisement.Show("video");
                // }
                // else{
                //     showIntersitionalAd();
                // }
                if(Yodo1U3dMas.IsInterstitialAdLoaded()){
                    Yodo1U3dMas.ShowInterstitialAd();
                }
            }
            UIMainScene.addCnt++;

        }
        
    }

    /*private InterstitialAd intersitional;

    private string appId="ca-app-pub-4962234576866611~2573814293";
    private string intersitionalId="ca-app-pub-4962234576866611/6955912430";

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

    // void OnCollisionEnter(Collision other){
    //     if(other.gameObject.tag=="MovablePlatform"){
    //         gameObject.transform.parent=other.gameObject.transform;
    //     }
    // }
    // void OnCollisionExit(Collision other){
    //     if(other.gameObject.tag=="MovablePlatform"){
    //         gameObject.transform.parent=null;
    //     }
    // }
    */

}
