using _BikiniPunchBeachBattle3D.Characters;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class RageIncreaseSystem : BaseInitSystem
    {
        public override void Init() => 
            _events.PunchPerformed.AddListener(IncreaseRage);

        public override void Dispose() => 
            _events.PunchPerformed.RemoveListener(IncreaseRage);

        private void IncreaseRage(CharacterType characterType, string side)
        {
            if (characterType == CharacterType.Player)
            {
                float increase = 1f / _configs.PunchesToRage;
                _data.RageValue = Mathf.Min(_data.RageValue + increase, 1f);
                
                _events.RageValueChanged.Invoke(increase);
            }            
        }
    }
}