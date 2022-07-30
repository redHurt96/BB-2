using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Characters
{
    public class ImpactAnimationProvider : MonoBehaviour
    {
        [SerializeField] private CharacterType _attackedByWho;
        [SerializeField] private Animator _animator;

        private EventsMediator _events;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _events.PunchPerformed.AddListener(TryAnimate);
        }

        private void OnDestroy() => 
            _events.PunchPerformed.RemoveListener(TryAnimate);

        private void TryAnimate(CharacterType type, string arg1)
        {
            if (type == _attackedByWho)
                _animator.SetTrigger("Impact");
        }
    }
}