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
    public partial class RewardedAdsHandler : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {

        // [Space(5), Header("[ Dependencies ]"), Space(10)]

        // bool _dependencies;


        [Space(5), Header("[ State ]"), Space(10)]

        bool _hasAvailableAd = false;
        public bool HasAvailableAd { get => _hasAvailableAd; }

        public Action OnInitializationFinishCallback = null;
        public Action<string, bool> OnAdAvailabilityUpdateCallback = null;


        // [Space(5), Header("[ Parts ]"), Space(10)]

        // bool _parts;


        [Space(5), Header("[ Configs ]"), Space(10)]

        [SerializeField] string _androidAdUnitId = "UNDEFINED";
        [SerializeField] string _iOSAdUnitId = "UNDEFINED";


        // void Awake()
        // {

        // }

        // void Start()
        // {

        // }

        // void Update()
        // {

        // }

        // void FixedUpdate()
        // {

        // }
    }
}
