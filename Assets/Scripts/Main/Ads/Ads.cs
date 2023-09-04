using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Ads : MonoBehaviour
{
    public static Ads Instance;
    public TMPro.TMP_Text text; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });
    }

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-8809019023559306/9567460373";
#endif

    private RewardedAd rewardedAd;

  /// <summary>
  /// Loads the rewarded ad.
  /// </summary>
  public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        text.text = "Loading the rewarded ad.";

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    text.text = "Rewarded ad failed to load an ad " +
                                   "with error : " + error;
                    return;
                }

                text.text = "Rewarded ad loaded with response : "
                          + ad.GetResponseInfo();

                rewardedAd = ad;
            });
    }

    public void ShowAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
            });
        }
    }
}
