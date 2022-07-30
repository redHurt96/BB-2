using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _BikiniPunchBeachBattle3D.PunchingBag
{
    public class PunchingBugAnimations : MonoBehaviour
    {
        private static readonly string[] _triggersNames = {"Hit_0", "Hit_1"};
        
        private Animator _animator;
        private EventsMediator _events;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _events.PunchPerformed.AddListener(Animate);
        }

        private void OnDestroy() => 
            _events.PunchPerformed.RemoveListener(Animate);

        private void Animate(CharacterType characterType, string side)
        {
            _animator ??= GetComponentInChildren<Animator>();
            _animator.SetTrigger(_triggersNames[Random.Range(0, _triggersNames.Length)]);
        }
    }
}