using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Characters
{
    [RequireComponent(typeof(FighterAnimator))]
    public class PunchAI : MonoBehaviour
    {
        private FighterAnimator _fighterAnimator;
        private DataService _data;
        private ConfigsService _configs;

        private float _lastPunchTime;
        private float _nextPunchDelay;
        
        private void Start()
        {
            _fighterAnimator = GetComponent<FighterAnimator>();
            _data = Services.Get<DataService>();
            _configs = Services.Get<ConfigsService>();

            _lastPunchTime = Time.time;
            CalculateDelay();
        }

        private void Update()
        {
            if (Time.time - _lastPunchTime > _nextPunchDelay
                && _data.GetStamina(CharacterType.Opponent) > _configs.StaminaPerHit)
            {
                _fighterAnimator.Punch();
                _lastPunchTime = Time.time;
            }
        }

        private void CalculateDelay() => 
            _nextPunchDelay = Random.Range(_configs.AiPunchDelayMin, _configs.AiPunchDelayMax);
    }
}