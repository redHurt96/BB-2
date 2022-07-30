using System;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Characters
{
    public class PunchEventProvider : MonoBehaviour
    {
        [SerializeField] private CharacterType _characterType;
        
        private EventsMediator _events;
        private DataService _data;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
        }

        private void PerformPunch(string side)
        {
            if (_data.GetHealth(_characterType) > 0)
                _events.PunchPerformed?.Invoke(_characterType, side);
        }
    }
}