using _BikiniPunchBeachBattle3D.UI.Windows;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class CreateHudSystem : BaseInitSystem
    {
        private readonly WindowsService _windowsService;

        public CreateHudSystem() => 
            _windowsService = Services.Get<WindowsService>();

        public override void Init() => 
            _windowsService.Show<HudWindow>();

        public override void Dispose() {}
    }
}