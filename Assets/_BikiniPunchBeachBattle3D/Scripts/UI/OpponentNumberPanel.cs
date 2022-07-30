using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class OpponentNumberPanel : MonoBehaviour
    {
        [SerializeField] private int _shift;
        [SerializeField] private Image _selectedOverlay;
        [SerializeField] private Text _number;
        
        private DataService _data;

        public void UpdateValue()
        {
            _data ??= Services.Get<DataService>();
            
            _selectedOverlay.enabled = _data.SavableData.OpponentLevel % 5 == _shift;
            
            if (_number != null)
                _number.text = (_data.SavableData.OpponentLevel / 5 * 5 + _shift).ToString();
        }
    }
}