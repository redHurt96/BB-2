using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class RageDecreaseSystem : BaseUpdateSystem
    {
        private float _lastPunchTime;

        public override void Init() => 
            _events.RageValueChanged.AddListener(ResetTimer);

        public override void Dispose() => 
            _events.RageValueChanged.RemoveListener(ResetTimer);

        public override void Update()
        {
            if (Time.time > _lastPunchTime + _configs.DecreaseRageDelay && _data.RageValue > 0f)
            {
                float decreaseValue = _configs.DecreaseRageSpeed * Time.deltaTime;
                _data.RageValue = Mathf.Max(_data.RageValue - decreaseValue, 0f);
                
                _events.RageValueChanged.Invoke(-decreaseValue);
            }
        }

        private void ResetTimer(float amount)
        {
            if (amount > 0f)
                _lastPunchTime = Time.time;
        }
    }
}