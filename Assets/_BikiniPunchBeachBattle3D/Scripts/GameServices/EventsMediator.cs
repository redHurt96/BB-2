using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.ServiceLocator;
using UnityEngine.Events;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class EventsMediator : IService
    {
        public UnityEvent<StatType> Upgraded = new UnityEvent<StatType>();
        public UnityEvent MoneysCountChanged = new UnityEvent();
        public UnityEvent<CharacterType> HealthAmountChanged = new UnityEvent<CharacterType>();
        public UnityEvent<CharacterType, float> StaminaAmountChanged = new UnityEvent<CharacterType, float>();
        public UnityEvent<CharacterType, string> PunchPerformed = new UnityEvent<CharacterType, string>();
        public UnityEvent<float> RageValueChanged = new UnityEvent<float>();
        public UnityEvent OpponentDefeated = new UnityEvent();
        public UnityEvent RewardedShown = new UnityEvent();
        public UnityEvent GlovesColorChanged = new UnityEvent();
    }
}