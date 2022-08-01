using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class SaveAfterUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            _events.Upgraded.AddListener(Save);

        public override void Dispose() => 
            _events.Upgraded.RemoveListener(Save);

        private void Save(StatType arg0) => 
            _data.SavableData.Save();
    }
}