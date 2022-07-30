using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _BikiniPunchBeachBattle3D.Characters
{
    public class FighterAnimator : MonoBehaviour
    {
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private float _delay;
        [Header("Used only on opponents. For player may be empty")]
        [SerializeField] private Transform _gfxAnchor;

        private ConfigsService _configs;
        private DataService _data;

        private Animator _animator;
        private float _lastAttackTime;

        private string _randomAttackTrigger => Random.value > .5f ? "Punch_1" : "Punch_2";

        private void Start()
        {
            _configs = Services.Get<ConfigsService>();
            _data = Services.Get<DataService>();

            if (_characterType == CharacterType.Opponent)
                LoadSkin();
            
            _animator = GetComponentInChildren<Animator>();
        }

        public void Punch()
        {
            if (Time.time < _lastAttackTime + _delay)
                return;
            
            _animator.SetTrigger(_randomAttackTrigger);
            _lastAttackTime = Time.time;
        }

        private void LoadSkin()
        {
            GameObject skin = _data.IsNextOpponentBoss 
                ? _configs.BossSkin 
                : _configs.OpponentSkins[Random.Range(0, _configs.OpponentSkins.Length)];

            Instantiate(skin, _gfxAnchor);
        }
    }
}