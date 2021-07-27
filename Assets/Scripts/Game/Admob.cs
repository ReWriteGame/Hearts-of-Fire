using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Admob", order = 1)]
public class Admob : ScriptableObject
{
	private InterstitialAd interstitial;
	private BannerView banner;

	[SerializeField] private string interstitialId;
	[SerializeField] private string bannerId;
	[SerializeField] private bool isBannerEnabled = false;
	[Range(0, 20), SerializeField] private int showFrequencyAds = 10;
	private void Start()
	{
		MobileAds.Initialize(init =>{});
		if(isBannerEnabled)
			RequestBannerAd();
	}

	#region AdMethods
	private void RequestInterstitialAd()
	{
        interstitial = new InterstitialAd(interstitialId);
        
        AdRequest request = new AdRequest.Builder().Build();
        
        interstitial.LoadAd(request);
        interstitial.OnAdLoaded += HandleOnInterLoaded;
        interstitial.OnAdClosed += DestroyInterAd;
	}
	
	private void RequestBannerAd()
	{
		banner = new BannerView(bannerId,AdSize.SmartBanner, AdPosition.Bottom);
        
		AdRequest request = new AdRequest.Builder().Build();
        
		banner.LoadAd(request);
		banner.OnAdLoaded += HandleOnAdLoaded;
		banner.OnAdClosed += DestroyBannerAd;
	}

	private void DestroyBannerAd()
	{
		banner?.Destroy ();
	}
	private void DestroyBannerAd(object a, EventArgs args)
	{
		banner?.Destroy();
	}

	private void HandleOnAdLoaded(object a, EventArgs args)
	{
		banner.Show();
	} 
	
	private void DestroyInterAd()
	{
		interstitial?.Destroy ();
	}
	private void DestroyInterAd(object a, EventArgs args)
	{
		interstitial?.Destroy();
	}

	private void HandleOnInterLoaded(object a, EventArgs args)
	{
		interstitial.Show();
	}

	private void OnDestroy()
	{
		DestroyBannerAd();
		DestroyInterAd();
	}
	#endregion

	private void OnEnable()
	{
		//GameStateController.showAd += RequestInterstitialAd;
	}

	private void OnDisable()
	{
		//GameStateController.showAd -= RequestInterstitialAd;
	}

    public void showRandomAds()
    {
        if (UnityEngine.Random.Range(0, showFrequencyAds) == 0)
        {
            RequestInterstitialAd();
            if (interstitial.IsLoaded())
                interstitial.Show();
        }
    }
}
