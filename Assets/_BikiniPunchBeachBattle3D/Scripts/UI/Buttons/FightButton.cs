using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class FightButton : BaseActionButton
    {
        private ActionsMediator _actions;

        protected override void PerformOnStart() => 
            _actions = Services.Get<ActionsMediator>();

        protected override void PerformOnClick()
        {
            _actions.GoToFight();
            gameObject.SetActive(false);
        }
    }
}