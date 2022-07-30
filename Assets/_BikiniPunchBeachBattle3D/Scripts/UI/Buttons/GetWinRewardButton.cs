using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _BikiniPunchBeachBattle3D.UI.Buttons
{
    public class GetWinRewardButton : BaseActionButton
    {
        private Wallet _wallet;
        private DataService _data;
        private ActionsMediator _actions;

        protected override void PerformOnStart()
        {
            _wallet = Services.Get<Wallet>();
            _data = Services.Get<DataService>();
            _actions = Services.Get<ActionsMediator>();
        }

        protected override void PerformOnClick()
        {
            int reward = _data.GetWinReward();
            _wallet.Add(reward);

            _actions.GoToMainHud(withOffer: true);
        }
    }
}