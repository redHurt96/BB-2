using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class InitStamina : BaseInitSystem
    {
        public override void Init() => 
            _actions.ResetStamina();

        public override void Dispose() {}
    }
}