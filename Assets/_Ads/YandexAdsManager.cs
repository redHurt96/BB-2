using System;
using InstantGamesBridge;

namespace _Ads
{
    public class YandexAdsManager : IAdsManager
    {
        public void ShowInter(string placement) => 
            Bridge.advertisement.ShowInterstitial();

        public void ShowBanner(string placement) {}//=> 
            //Bridge.advertisement.ShowBanner();

        public void HideBanner() {}//=> 
            //Bridge.advertisement.HideBanner();

        public void ShowRewardVideo(string placement, Action func = null) =>
            Bridge.advertisement.ShowRewarded(success =>
            {
                if (success)
                    func?.Invoke();
            });
    }
}