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

// from company
using JovDK.Debugging;
using JovDK.SafeActions;
using JovDK.SerializingTools.Json;

// from project
// ...


namespace JovDK.App.Monetization.UnityAds.Testing.Showcase
{
    public partial class Asmb_UnityAdsRewardedAdShowcaseScene : MonoBehaviour
    {
        void SubscribeAllListeners()
        {
            _adsInitializer.DoIfNotNull(() =>
            {
                _adsInitializer.OnInitializationCompleteCallback += OnAdsInitializationComplete;
                _adsInitializer.OnInitializationFailedCallback += OnInitializationFailed;

            });
            _rewardedAdsHandler.DoIfNotNull(() => _rewardedAdsHandler.OnAdAvailabilityUpdateCallback += OnAdAvailabilityUpdate);
        }

        void OnAdsInitializationComplete()
        {
            DebugExtension.NDLog(
                "#> ".ToColor(GoodColors.Pink) +
                "OnAdsInitializationComplete" + "\n" +
                "");

            _rewardedAdsHandler.LoadRewardedAd();
        }

        void OnInitializationFailed(
            UnityAdsInitializationError error,
            string message)
        {
            DebugExtension.NDLog(
                "#> ".ToColor(GoodColors.Pink) +
                "OnInitializationFailed" + "\n" +
                "message = \"" + message + "\"" + "\n" +
                "error = " + "\n" +
                error.SerializeObjectToJSON(true) + "\n" +
                "");
        }

        void OnAdAvailabilityUpdate(string adUnitId, bool isAvailable)
        {
            DebugExtension.NDLog(
                "#> " +
                "OnAdAvailabilityUpdate | " +
                "adUnitId = \"" + adUnitId + "\" | " +
                "isAvailable = " + isAvailable);

            _hasAvailableAd = isAvailable;
            RefreshButtonState();
        }

        void RefreshButtonState()
        {
            _whatchAdButton.interactable = _hasAvailableAd;
        }
    }
}
