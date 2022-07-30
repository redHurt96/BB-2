using RH.Utilities.PseudoEcs;
using TMPro;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class CreateNewPunchingBagSystem : BaseInitSystem
    {
        public override void Init() => 
            _events.OpponentDefeated.AddListener(CreateNewIfItsPunchingBag);

        public override void Dispose() => 
            _events.OpponentDefeated.RemoveListener(CreateNewIfItsPunchingBag);

        private void CreateNewIfItsPunchingBag()
        {
            _actions.DestroyCurrentOpponent();
            _actions.CreatePunchingBag();
        }
    }
}