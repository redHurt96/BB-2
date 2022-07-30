using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class CharacterHealthBar : MonoBehaviour
    {
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private Image _slider;
        
        private EventsMediator _events;
        private DataService _data;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _data = Services.Get<DataService>();

            UpdateValue();
            
            _events.HealthAmountChanged.AddListener(UpdateValue);
        }

        private void OnDestroy() => 
            _events?.HealthAmountChanged.RemoveListener(UpdateValue);

        private void UpdateValue(CharacterType characterType)
        {
            if (_characterType == characterType)
                UpdateValue();
        }

        private void UpdateValue() => 
            _slider.fillAmount = (float) _data.GetHealth(_characterType) / _data.GetMaxHealth(_characterType);
    }
}