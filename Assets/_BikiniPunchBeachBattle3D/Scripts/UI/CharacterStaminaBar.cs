using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class CharacterStaminaBar : MonoBehaviour
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
            
            _events.StaminaAmountChanged.AddListener(UpdateValue);
        }

        private void OnDestroy() => 
            _events?.StaminaAmountChanged.RemoveListener(UpdateValue);

        private void UpdateValue(CharacterType characterType, float amount)
        {
            if (characterType == _characterType)
                UpdateValue();
        }

        private void UpdateValue() =>
            _slider.fillAmount = _data.GetStamina(_characterType) / _data.GetMaxStamina(_characterType);
    }
}