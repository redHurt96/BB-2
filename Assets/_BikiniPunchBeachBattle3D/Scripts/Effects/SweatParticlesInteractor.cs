using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Effects
{
    public class SweatParticlesInteractor : MonoBehaviour
    {
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private ParticleSystem _particleSystem;
        
        private DataService _data;
        private EventsMediator _events;
        private ConfigsService _configs;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            _configs = Services.Get<ConfigsService>();
            
            _events.StaminaAmountChanged.AddListener(TryEmit);
        }

        private void OnDestroy() => 
            _events.StaminaAmountChanged.RemoveListener(TryEmit);

        private void TryEmit(CharacterType character, float value)
        {
            if (character != _characterType)
                return;
            
            if (_data.GetStamina(character) / _data.GetMaxStamina(character) < _configs.SweatThreshold)
                _particleSystem.Play();
            else
                _particleSystem.Stop();
        }
    }
}