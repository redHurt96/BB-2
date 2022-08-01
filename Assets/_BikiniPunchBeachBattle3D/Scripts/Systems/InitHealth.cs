using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class InitHealth : BaseInitSystem
    {
        public override void Init() => 
            _actions.ResetHealth();

        public override void Dispose() {}
    }
}