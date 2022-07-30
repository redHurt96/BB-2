using System.Collections.Generic;
using _BikiniPunchBeachBattle3D.Characters;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class RestoreStaminaSystem : BaseUpdateSystem
    {
        private Dictionary<CharacterType, double> _lastChangedTimes = new Dictionary<CharacterType, double>()
        {
            [CharacterType.Player] = Time.time,
            [CharacterType.Opponent] = Time.time,
        };
        
        public override void Init() => 
            _events.StaminaAmountChanged.AddListener(ResetTimerBeforeRestore);

        public override void Dispose() => 
            _events.StaminaAmountChanged.RemoveListener(ResetTimerBeforeRestore);

        public override void Update()
        {
            float time = Time.time;
            
            foreach (KeyValuePair<CharacterType,double> pair in _lastChangedTimes)
                if (pair.Value < time - _configs.RestoreStaminaDelay)
                    TryRestoreStamina(pair);
        }

        private void TryRestoreStamina(KeyValuePair<CharacterType, double> pair)
        {
            if (_data.GetStamina(pair.Key) < _data.GetMaxStamina(pair.Key))
            {
                float restored = _configs.RestoreStaminaSpeed * Time.deltaTime;
                _data.GetStats(pair.Key).CurrentStamina += restored;
                _events.StaminaAmountChanged.Invoke(pair.Key, restored);
            }
        }

        private void ResetTimerBeforeRestore(CharacterType characterType, float amount)
        {
            if (amount > 0)
                return;
            
            _lastChangedTimes[characterType] = Time.time;
        }
    }
}