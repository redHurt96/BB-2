using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class IncreaseHealthByStrengthUpgrade : BaseInitSystem
    {
        public override void Init() => 
            _events.Upgraded.AddListener(IncreaseIfStrengthUpgraded);

        public override void Dispose() => 
            _events.Upgraded.RemoveListener(IncreaseIfStrengthUpgraded);

        private void IncreaseIfStrengthUpgraded(StatType type)
        {
            if (type == StatType.Strength)
            {
                _actions.ResetHealth();
                
                _events.HealthAmountChanged.Invoke(CharacterType.Player);
            }
        }
    }
}