using System;
using RH.Utilities.ServiceLocator;

namespace _Ads
{
    public interface IAdsManager : IService
    {
        void ShowInter(string placement);
        void ShowBanner(string placement);
        void HideBanner();
        void ShowRewardVideo(string placement,Action func=null);
    }
}