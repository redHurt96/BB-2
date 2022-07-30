using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class SaveLoadSystem : BaseInitSystem
    {
        public override void Init() => LoadIfExist();
        public override void Dispose() => Save();

        private void Save() => _data.SavableData.Save();
        private void LoadIfExist() => _data.SavableData.LoadIfExist();
    }
}