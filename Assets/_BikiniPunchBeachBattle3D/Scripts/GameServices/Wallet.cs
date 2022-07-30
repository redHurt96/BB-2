using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class Wallet : IService
    {
        private readonly DataService _data;
        private readonly EventsMediator _events;

        public Wallet()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
        }

        public void Remove(int amount)
        {
            if (_data.SavableData.MoneyAmount < amount)
                Debug.LogError($"Cannot remove more money than player has");
            else
                ChangeMoneysAmount(-amount);
        }

        public void Add(int amount) => 
            ChangeMoneysAmount(amount);

        private void ChangeMoneysAmount(int amount)
        {
            _data.SavableData.MoneyAmount += amount;
            _events.MoneysCountChanged.Invoke();
        }
    }
}