using System;
using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.PunchingBag
{
    public class GraphicsByHealthSwitcher : MonoBehaviour
    {
        [SerializeField] private Transform _graphicsParent;
        
        private DataService _data;
        private EventsMediator _events;
        private ConfigsService _configs;

        private int _currentGraphicsIndex;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            _configs = Services.Get<ConfigsService>();
            
            _events.HealthAmountChanged.AddListener(UpdateGraphics);

            SetGraphics(3);
        }

        private void OnDestroy() => 
            _events.HealthAmountChanged.RemoveListener(UpdateGraphics);

        private void UpdateGraphics(CharacterType type)
        {
            if (type == CharacterType.Opponent)
                UpdateGraphics();
        }

        private void UpdateGraphics()
        {
            float healthPercent = (float)_data.GetHealth(CharacterType.Opponent) / _data.GetMaxHealth(CharacterType.Opponent);

            for (int i = 0; i < _configs.GraphicsByHealth.Length; i++)
            {
                if (_configs.GraphicsByHealth[i].HealthPercent >= healthPercent)
                {
                    SetGraphics(i);
                    break;
                }
            }
        }

        private void SetGraphics(int index)
        {
            if (_currentGraphicsIndex == index && _graphicsParent.childCount != 0)
                return;
            
            if (_graphicsParent.childCount != 0)
                Destroy(_graphicsParent.GetChild(0).gameObject);
            
            Instantiate(_configs.GraphicsByHealth[index].Graphics, _graphicsParent);
            _currentGraphicsIndex = index;
        }
    }
}
