using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.Scripts.UI
{
    public class StatValueTitle : MonoBehaviour
    {
        [SerializeField] private StatType _targetType;
        
        private EventsMediator _events;
        private DataService _data;
        private Text _title;

        private void Start()
        {
            _title = GetComponent<Text>();
            
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            
            _events.Upgraded.AddListener(UpdateTitle);

            UpdateTitle();
        }

        private void OnDestroy() => 
            _events?.Upgraded.RemoveListener(UpdateTitle);

        private void UpdateTitle(StatType statType)
        {
            if (statType == _targetType)
                UpdateTitle();
        }

        private void UpdateTitle() => 
            _title.text = _data.GetStatValue(_targetType, CharacterType.Player).ToString();
    }
}