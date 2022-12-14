using System;
using RH.Utilities.ServiceLocator;

namespace _Ads
{
    public interface IAdsService : IService
    {
        bool AdsInit { get; }
        void ShowInter(string placement);
        void ShowInter(float pause,string placement);
        void ShowBanner(string placement);
        void HideBanner();
        void ShowRewardVideo(string placement,Action func=null);
    }
}