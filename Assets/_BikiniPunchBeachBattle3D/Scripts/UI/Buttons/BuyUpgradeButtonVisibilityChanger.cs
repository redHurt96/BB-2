using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    [RequireComponent(typeof(Button))]
    public class BuyUpgradeButtonVisibilityChanger : MonoBehaviour
    {
        [SerializeField] private StatType _statType;
        
        private Button _button;

        private DataService _data;
        private EventsMediator _events;

        private void Start()
        {
            _button = GetComponent<Button>();

            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            
            _events.MoneysCountChanged.AddListener(UpdateVisibility);
            
            UpdateVisibility();
        }

        private void OnDestroy() => 
            _events.MoneysCountChanged.RemoveListener(UpdateVisibility);

        private void UpdateVisibility() => 
            _button.interactable = _data.SavableData.MoneyAmount >= _data.GetUpgradePrice(_statType);
    }
}