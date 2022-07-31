using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class ShowBannerSystem : BaseInitSystem
    {
        public override void Init() =>
            Services
                .Get<MaxAdsManager>()
                .ShowBaner("Main scene");

        public override void Dispose() {}
    }
}