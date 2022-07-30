using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.Extensions;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _BikiniPunchBeachBattle3D.Characters
{
    [RequireComponent(typeof(FighterAnimator))]
    public class PunchInputProvider : MonoBehaviour
    {
        private FighterAnimator _fighterAnimator;
        private DataService _data;
        private ConfigsService _configs;

        private void Start()
        {
            _fighterAnimator = GetComponent<FighterAnimator>();
            _data = Services.Get<DataService>();
            _configs = Services.Get<ConfigsService>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) 
                && !EventSystem.current.IsOverUi() 
                && _data.GetStamina(CharacterType.Player) >= _configs.StaminaPerHit)
                _fighterAnimator.Punch();
        }
    }
}