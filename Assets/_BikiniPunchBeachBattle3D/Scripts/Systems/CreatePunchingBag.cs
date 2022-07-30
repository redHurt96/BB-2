using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class CreatePunchingBag : BaseInitSystem
    {
        public override void Init() =>
            _actions.CreatePunchingBag();

        public override void Dispose() {}
    }
}