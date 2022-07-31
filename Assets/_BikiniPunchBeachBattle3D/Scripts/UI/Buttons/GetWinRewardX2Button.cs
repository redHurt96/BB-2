using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _BikiniPunchBeachBattle3D.UI.Buttons
{
    public class GetWinRewardX2Button : BaseActionButton
    {
        private MaxAdsManager _ads;
        private Wallet _wallet;
        private DataService _data;
        private ActionsMediator _actions;

        protected override void PerformOnStart()
        {
            _ads = Services.Get<MaxAdsManager>();    
            _wallet = Services.Get<Wallet>();
            _data = Services.Get<DataService>();
            _actions = Services.Get<ActionsMediator>();
        }

        protected override void PerformOnClick() =>
            _ads.ShowRewardVideo("fight_reward", () =>
            {
                int reward = _data.GetWinReward();
                _wallet.Add(reward * 2);
            
                _actions.GoToMainHud(withOffer: true);
            });
    }
}