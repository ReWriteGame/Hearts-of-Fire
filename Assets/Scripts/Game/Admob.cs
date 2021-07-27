using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Admob : MonoBehaviour
{
	private InterstitialAd interstitial;
	private BannerView banner;

	[SerializeField] private string interstitialId;
	[SerializeField] private string bannerId;
	[SerializeField] private bool isBannerEnabled = false;
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
}
