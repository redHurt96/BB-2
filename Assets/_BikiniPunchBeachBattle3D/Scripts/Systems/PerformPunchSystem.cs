using _BikiniPunchBeachBattle3D.Characters;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class PerformPunchSystem : BaseInitSystem
    {
        public override void Init() => 
            _events.PunchPerformed.AddListener(PerformPunch);

        public override void Dispose() => 
            _events.PunchPerformed.RemoveListener(PerformPunch);

        private void PerformPunch(CharacterType character, string side)
        {
            switch (character)
            {
                case CharacterType.Player:
                    _actions.HitOpponent();
                    break;
                case CharacterType.Opponent:
                    _actions.HitPlayer();
                    break;
            }
        }
    }
}