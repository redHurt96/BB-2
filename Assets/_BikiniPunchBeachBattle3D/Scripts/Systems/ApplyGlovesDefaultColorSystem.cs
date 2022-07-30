using RH.Utilities.PseudoEcs;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class ApplyGlovesDefaultColorSystem : BaseInitSystem
    {
        public override void Init()
        {
            if (_data.SavableData.GlovesColor == default)
                _data.SavableData.GlovesColor = _configs.DefaultGlovesColor;
            
            if (_data.SavableData.GlovesColor != _configs.DefaultGlovesColor)
                _sceneRefs.PlayerGloves.Create();
        }

        public override void Dispose() {}
    }
}