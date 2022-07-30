using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class ComboPanel : MonoBehaviour
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _value;
        
        private DataService _data;
        private EventsMediator _events;
        
        private int _comboCount;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            
            _events.PunchPerformed.AddListener(IncreaseCounter);
            _events.OpponentDefeated.AddListener(ClearCounter);
        }

        private void OnDestroy()
        {
            _events.PunchPerformed.RemoveListener(IncreaseCounter);
            _events.OpponentDefeated.RemoveListener(ClearCounter);
        }

        private void IncreaseCounter(CharacterType characterType, string arg1)
        {
            if (characterType == CharacterType.Player && !_data.IsOpponentPunchingBag)
            {
                if (!_value.enabled)
                    _value.enabled = true;
                
                if (!_title.enabled)
                    _title.enabled = true;
                
                _comboCount++;
                _value.text = $"x{_comboCount}";
            }
        }

        private void ClearCounter()
        {
            _comboCount = 0;
            
            _value.enabled = false;
            _title.enabled = false;
        }
    }
}