using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class AdsRewarded : MonoBehaviour
{
    [SerializeField] Button continueButton;
    private string RewardedUnitId = "ca-app-pub-6259055093228667/2529447184";
    private RewardedAd rewardedAd;

    private void Start()
    {
        continueButton.interactable = false;
    }

    private void OnEnable()
    {
        rewardedAd = new RewardedAd(RewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();     
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdLoaded += HandleAdLoaded;
        rewardedAd.OnAdClosed += HandleAdClosed;
        rewardedAd.LoadAd(adRequest);
    }

    private void HandleAdClosed(object sender, EventArgs e)
    {
        continueButton.interactable = false;
    }

    private void HandleAdLoaded(object sender, EventArgs e)
    {
        continueButton.interactable = true;
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        FindObjectOfType<SceneLoader>().RestartGameSafety();
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }    
    }
}
