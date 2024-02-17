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
        public void InitializeAds()
        {
            _gameId = GetGameId();

            bool testMode = false;

#if UNITY_EDITOR
            testMode = _testMode;
#endif

            if (!Advertisement.isInitialized && Advertisement.isSupported)
                Advertisement.Initialize(_gameId, testMode, this);
        }

        string GetGameId()
        {
            string value = "";

            // Get the Game ID for the current platform:
#if UNITY_ANDROID
            value = _androidGameId;
#elif UNITY_IPHONE
            value = _iOSGameId;
#endif

            return value;
        }
    }
}
