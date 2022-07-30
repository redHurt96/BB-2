using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class BuyUpgradeButton : BaseActionButton
    {
        [SerializeField] private StatType _statType;
        
        private ActionsMediator _actions;

        protected override void PerformOnStart() => 
            _actions = Services.Get<ActionsMediator>();

        protected override void PerformOnClick() => 
            _actions.BuyUpgrade(_statType);
    }
}