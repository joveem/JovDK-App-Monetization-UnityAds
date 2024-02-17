// system / unity
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
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
        void SetInitialState()
        {
            _hasAvailableAd = _rewardedAdsHandler.HasAvailableAd;
        }
    }
}
