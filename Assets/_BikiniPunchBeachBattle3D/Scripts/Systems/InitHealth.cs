using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class InitHealth : BaseInitSystem
    {
        public override void Init()
        {
            if (_data.SavableData.Player.MaxHealth == 0)
                _data.SavableData.Player.MaxHealth = _configs.PlayerHealth;
            
            if (_data.SavableData.Opponent.MaxHealth == 0)
                _data.SavableData.Opponent.MaxHealth = _configs.PlayerHealth;
            
            _actions.ResetHealth();
        }

        public override void Dispose() {}
    }
}