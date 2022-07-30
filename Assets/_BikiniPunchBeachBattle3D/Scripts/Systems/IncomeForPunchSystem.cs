using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class IncomeForPunchSystem : BaseInitSystem
    {
        private readonly Wallet _wallet;

        public IncomeForPunchSystem() => 
            _wallet = Services.Get<Wallet>();

        public override void Init() => 
            _events.PunchPerformed.AddListener(AddMoneys);

        public override void Dispose() => 
            _events.PunchPerformed.RemoveListener(AddMoneys);

        private void AddMoneys(CharacterType characterType, string side)
        {
            if (characterType == CharacterType.Player)
            {
                int income = _data.GetPunchIncome();
                
                _wallet.Add(income);
            }
        }
    }
}