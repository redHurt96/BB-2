using System;
using UnityEngine;

namespace _Ads
{
    public class YandexAdsService : IAdsService
    {
        public bool AdsInit { get; }
        public void ShowInter(string placement)
        {
            Debug.LogError("Show inter");
        }

        public void ShowInter(float pause, string placement)
        {
            Debug.LogError("Show inter");

        }

        public void ShowBanner(string placement)
        {
            Debug.LogError("Show banner");

        }

        public void HideBanner()
        {
            Debug.LogError("hide banner");

        }

        public void ShowRewardVideo(string placement, Action func = null)
        {
            Debug.LogError("Show rewarded");
        }
    }
}