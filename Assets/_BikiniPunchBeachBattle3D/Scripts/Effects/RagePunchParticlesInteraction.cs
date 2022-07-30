using System;
using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;

namespace _BikiniPunchBeachBattle3D.Effects
{
    public class RagePunchParticlesInteraction : PunchParticlesInteraction
    {
        private DataService _data;

        protected override void Start()
        {
            base.Start();
            
            _data = Services.Get<DataService>();
        }

        protected override bool CanShowFx(CharacterType type, string side) => 
            base.CanShowFx(type, side) && _data.InRageMode;
    }
}