using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
using TMPro;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.DebugServices
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AddMoneyButton : BaseActionButton
    {
        [SerializeField] private int _amount;
        
        private Wallet _wallet;

        protected override void PerformOnStart()
        {
            GetComponent<TextMeshProUGUI>().text = $"+{_amount}";
            
            _wallet = Services.Get<Wallet>();
        }

        protected override void PerformOnClick() => 
            _wallet.Add(_amount);
    }
}