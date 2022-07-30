using _BikiniPunchBeachBattle3D.UI.Windows;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class ShowWinRewardWindowSystem : BaseInitSystem
    {
        private readonly WindowsService _windowsService;

        public ShowWinRewardWindowSystem() => 
            _windowsService = Services.Get<WindowsService>();

        public override void Init() => 
            _events.OpponentDefeated.AddListener(ShowRewardWindow);

        public override void Dispose() => 
            _events.OpponentDefeated.RemoveListener(ShowRewardWindow);

        private void ShowRewardWindow()
        {
            if (!_data.IsOpponentPunchingBag)
            {
                _windowsService.HideTopWindow();
                _windowsService.Show<WinRewardWindow>();
            }
        }
    }
}