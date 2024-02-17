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
        // This will be "N/A" for unsupported platforms
        string GetRewardedAdId()
        {
            string value = "";

            // Get the Ad Unit ID for the current platform:
#if UNITY_ANDROID
            value = _androidAdUnitId;
#elif UNITY_IPHONE
            value = _iOSAdUnitId;
#else
            value = "N/A";
#endif

            return value;
        }

        // Call this public method when you want to get an ad ready to show.
        /// <summary>
        /// Loads the rewarded ad.
        /// </summary>
        public void LoadRewardedAd()
        {
            // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
            Debug.Log("Loading Ad: " + GetRewardedAdId());
            Advertisement.Load(GetRewardedAdId(), this);
        }

        // Implement a method to execute when the user clicks the button:
        public void ShowRewardedAd()
        {
            OnAdAvailabilityUpdate("n/a", false);
            // Then show the ad:
            Advertisement.Show(GetRewardedAdId(), this);
        }
    }
}
