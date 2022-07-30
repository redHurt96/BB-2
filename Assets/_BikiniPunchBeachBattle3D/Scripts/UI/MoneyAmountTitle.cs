using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI
{
    [RequireComponent(typeof(Text))]
    public class MoneyAmountTitle : MonoBehaviour
    {
        private EventsMediator _events;
        private DataService _data;
        private Text _title;

        private void Start()
        {
            _title = GetComponent<Text>();
            
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            
            _events.MoneysCountChanged.AddListener(UpdateTitle);

            UpdateTitle();
        }

        private void OnDestroy() => 
            _events?.MoneysCountChanged.RemoveListener(UpdateTitle);

        private void UpdateTitle() => 
            _title.text = _data.SavableData.MoneyAmount.ToString();
    }
}