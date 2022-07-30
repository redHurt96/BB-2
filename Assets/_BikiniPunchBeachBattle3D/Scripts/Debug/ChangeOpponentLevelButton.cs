using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.DebugServices
{
    public class ChangeOpponentLevelButton : BaseActionButton
    {
        [SerializeField] private int _value;
        protected override void PerformOnClick()
        {
            DataService dataService = Services.Get<DataService>();
            dataService.SavableData.OpponentLevel += _value;
            
            Debug.Log($"Opponent level set to {dataService.SavableData.OpponentLevel}");
        }
    }
}