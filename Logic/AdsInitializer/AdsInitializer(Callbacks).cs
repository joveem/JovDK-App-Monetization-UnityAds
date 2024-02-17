// system / unity
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

// third
using TMPro;

// from company
using JovDK.Debugging;
using JovDK.SafeActions;
using JovDK.SerializingTools.Json;

// from project
// ...


namespace JovDK.App.Monetization.UnityAds
{
    public partial class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        void IUnityAdsInitializationListener.OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            OnInitializationCompleteCallback?.Invoke();
        }

        void IUnityAdsInitializationListener.OnInitializationFailed(
            UnityAdsInitializationError error,
            string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
            OnInitializationFailedCallback?.Invoke(error, message);
        }
    }
}
