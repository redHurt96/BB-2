using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Effects
{
    public class PunchParticlesInteraction : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private string _punchSide;
        
        private EventsMediator _events;
        
        protected virtual void Start()
        {
            _events = Services.Get<EventsMediator>();
            
            _events.PunchPerformed.AddListener(Emit);
        }

        private void OnDestroy() => 
            _events.PunchPerformed.RemoveListener(Emit);

        protected virtual bool CanShowFx(CharacterType type, string side) =>
            type == CharacterType.Player && side == _punchSide;
        
        private void Emit(CharacterType type, string side)
        {
            if (CanShowFx(type, side))
                _particleSystem.Play();
        }
    }
}