using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class RageBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private Slider _slider;
        
        private EventsMediator _events;
        private DataService _data;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _data = Services.Get<DataService>();

            _events.RageValueChanged.AddListener(UpdateBar);
        }

        private void OnDestroy() => 
            _events.RageValueChanged.RemoveListener(UpdateBar);

        private void UpdateBar(float amount)
        {
            _fill.fillAmount = _data.RageValue;
            _slider.value = _data.RageValue;
        }
    }
}