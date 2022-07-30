using _Game.GameServices;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.UI.Windows
{
    public class HudWindow : BaseWindow
    {
        [SerializeField] private GameObject _fightButton;
        [SerializeField] private OpponentNumberPanel[] _opponentNumberPanels;

        private void OnEnable()
        {
            if (!_fightButton.activeSelf)
                _fightButton.SetActive(true);

            foreach (OpponentNumberPanel panel in _opponentNumberPanels) 
                panel.UpdateValue();
        }
    }
}