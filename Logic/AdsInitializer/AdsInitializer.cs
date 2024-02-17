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

        // [Space(5), Header("[ Dependencies ]"), Space(10)]

        // bool _dependencies;


        // [Space(5), Header("[ State ]"), Space(10)]

        // bool _state;


        [Space(5), Header("[ Parts ]"), Space(10)]

        public Action OnInitializationCompleteCallback = null;
        public Action<UnityAdsInitializationError, string> OnInitializationFailedCallback = null;


        // [Space(5), Header("[ Configs ]"), Space(10)]

        [SerializeField] string _androidGameId;
        [SerializeField] string _iOSGameId;
        [SerializeField] bool _testMode = true;
        private string _gameId;

        void Awake()
        {
            InitializeAds();
        }

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
