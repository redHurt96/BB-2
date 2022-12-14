using System;
using System.Collections.Generic;
using _Ads;
using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using _BikiniPunchBeachBattle3D.UI.Windows.Components;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _BikiniPunchBeachBattle3D.UI.Windows
{
    public class GlovesOfferWindow : BaseWindow
    {
        [SerializeField] private StatIncreasePanel[] _statIncreasePanels;
        [SerializeField] private Button _buyButton;
        
        private ConfigsService _configs;
        private DataService _data;
        private SceneRefs _sceneRefs;
        private ActionsMediator _actions;

        private Color _color;
        private Dictionary<StatType,int> _stats;

        private void OnEnable()
        {
            _configs ??= Services.Get<ConfigsService>();
            _sceneRefs ??= Services.Get<SceneRefs>();
            _data ??= Services.Get<DataService>();
            _actions ??= Services.Get<ActionsMediator>();

            _color = _configs.GlovesColors[Random.Range(0, _configs.GlovesColors.Length)];

            ShowGlovesOnScreen();
            ShowStats();
        }

        private void OnDisable() => 
            _sceneRefs.GlovesForOffer.Disable();

        private void Start() => 
            _buyButton.onClick.AddListener(Buy);

        private void OnDestroy() => 
            _buyButton.onClick.RemoveListener(Buy);

        private void Buy() =>
            Services.Get<IAdsService>().ShowRewardVideo("boss_fight_win", () =>
            {
                _data.SetGlovesColor(_color);
                _data.AddStats(_stats);
                _actions.GoToMainHud(withOffer: false);
            });

        private void ShowGlovesOnScreen() => 
            _sceneRefs.GlovesForOffer.
                SetColor(_color);

        private void ShowStats()
        {
            _stats = _data.CreateRandomAddendStats();
            int i = 0;

            foreach (KeyValuePair<StatType,int> stat in _stats)
            {
                _statIncreasePanels[i].Setup(stat);
                i++;
            }

            for (; i < _statIncreasePanels.Length; i++) 
                _statIncreasePanels[i].Hide();
        }
    }
}