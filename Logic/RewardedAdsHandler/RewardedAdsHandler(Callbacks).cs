// system / unity
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

// third
using TMPro;
using GoogleMobileAds;
using GoogleMobileAds.Api;

// from company
using JovDK.Debugging;
using JovDK.SafeActions;
using JovDK.SerializingTools.Json;

// from project
// ...


namespace JovDK.App.Monetization.UnityAds
{
    public partial class RewardedAdsHandler : MonoBehaviour
    {
        void OnAdAvailabilityUpdate(string adUnitId, bool isAvailable)
        {
            _hasAvailableAd = isAvailable;
            OnAdAvailabilityUpdateCallback?.Invoke(adUnitId, isAvailable);
        }

        #region Loading
        // If the ad successfully loads, add a listener to the button and enable it:
        void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string adUnitId)
        {
            Debug.Log("Ad Loaded: " + adUnitId);

            if (adUnitId.Equals(GetRewardedAdId()))
                OnAdAvailabilityUpdate(adUnitId, true);
        }

        // Implement Load and Show Listener error callbacks:
        void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
            // Use the error details to determine whether to try to load another ad.
        }
        #endregion Loading

        #region Showing
        // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
        void IUnityAdsShowListener.OnUnityAdsShowComplete(
            string adUnitId,
            UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(GetRewardedAdId()) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                Debug.Log("Unity Ads Rewarded Ad Completed");
                // Grant a reward.
            }

            LoadRewardedAd();
        }

        void IUnityAdsShowListener.OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
            // Use the error details to determine whether to try to load another ad.
        }

        void IUnityAdsShowListener.OnUnityAdsShowStart(string adUnitId)
        {
            DebugExtension.DevLog("#>".ToColor(GoodColors.Pink));
        }

        void IUnityAdsShowListener.OnUnityAdsShowClick(string adUnitId)
        {
            DebugExtension.DevLog("#>".ToColor(GoodColors.Pink));
        }
        #endregion Showing
    }
}
