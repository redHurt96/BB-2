using System;
using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Effects
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private EventsMediator _events;
        private DataService _data;
        
        private Collider[] _colliders;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _data = Services.Get<DataService>();
            
            _events.HealthAmountChanged.AddListener(EnableIfDead);
        }

        private void EnableIfDead(CharacterType arg0)
        {
            if (_data.GetHealth(CharacterType.Opponent) <= 0f)
            {
                _events.HealthAmountChanged.RemoveListener(EnableIfDead);
                EnableAnimatedFall();
            }
        }

        private void EnableAnimatedFall()
        {
            _animator.SetBool("Death", true);
            _animator.SetTrigger("Die");

            // Destroy(GetComponentInParent<PunchAI>());
            // Destroy(GetComponentInParent<FighterAnimator>());
            //
            // Destroy(GetComponent<PunchEventProvider>());
            // Destroy(GetComponent<ImpactAnimationProvider>());
        }
        // [ContextMenu(nameof(Enable))]
        // private void Enable() => SetActive(true);
        //
        // [ContextMenu(nameof(Disable))]
        // private void Disable() => SetActive(false);
        //
        // private void SetActive(bool isActive)
        // {
        //     _colliders ??= GetComponentsInChildren<Collider>();
        //     var rigidbodies = GetComponentsInChildren<Rigidbody>();
        //     
        //     _animator.enabled = !isActive;
        //
        //     foreach (Collider collider in _colliders) 
        //         collider.enabled = isActive;
        //
        //     foreach (Rigidbody rigidbody in rigidbodies) 
        //         rigidbody.velocity = Vector3.zero;
        // }
    }
}