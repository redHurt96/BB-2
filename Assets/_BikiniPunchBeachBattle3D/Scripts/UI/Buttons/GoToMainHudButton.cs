using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _BikiniPunchBeachBattle3D.UI.Buttons
{
    public class GoToMainHudButton : BaseActionButton
    {
        private ActionsMediator _actions;

        protected override void PerformOnStart() => 
            _actions = Services.Get<ActionsMediator>();

        protected override void PerformOnClick() => 
            _actions.GoToMainHud(withOffer: false);
    }
}