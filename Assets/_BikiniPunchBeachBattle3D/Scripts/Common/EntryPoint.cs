using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Systems;
using _Game.GameServices;
using _Game.Logic.Systems;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Common
{
    public class EntryPoint : AbstractEntryPoint
    {
        [SerializeField] private ConfigsService _configs;
        [SerializeField] private SceneRefs _sceneRefs;

        protected override void RegisterServices() =>
            _services
                .RegisterSingle(_configs)
                .RegisterSingle(_sceneRefs)
                .RegisterSingle(new EventsMediator())
                .RegisterSingle(new DataService())
                .RegisterSingle(new Wallet())
                .RegisterSingle(new WindowsService())
                .RegisterSingle(new ActionsMediator())
                .RegisterSingle(GameObject.Find("MaxAdsManager").GetComponent<MaxAdsManager>());

        protected override void RegisterSystems() =>
            _systems
                .Add(new SaveLoadSystem())
                .Add(new SaveAfterUpgradeSystem())
                .Add(new InitHealth())
                .Add(new InitStamina())
                .Add(new IncreaseHealthByStrengthUpgrade())
                .Add(new CreatePunchingBag())
                .Add(new CreateHudSystem())
                .Add(new PerformPunchSystem())
                .Add(new RestoreStaminaSystem())
                .Add(new ShowWinRewardWindowSystem())
                .Add(new CreateNewPunchingBagSystem())
                .Add(new IncomeForPunchSystem())
                .Add(new RageIncreaseSystem())
                .Add(new RageDecreaseSystem())
                .Add(new ApplyGlovesDefaultColorSystem())
                
                //ADS
                .Add(new InterstitialAdvSystem())
                .Add(new ShowBannerSystem());
    }
}