using System.Collections.Generic;
using System.Linq;
using _BikiniPunchBeachBattle3D.Characters;
using _Game.Data;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.Extensions;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class DataService : IService
    {
        public SavableData SavableData = new SavableData();
        public GameObject CurrentOpponentGO 
        { 
            get;
            set;
        }
        public float RageValue { get; set; }
        public int LeaderboardPlace { get; set; }
        public bool IsOpponentDefended { get; set; }

        private readonly ConfigsService _configs;
        private readonly EventsMediator _events;
        private readonly SceneRefs _sceneRefs;

        public DataService()
        {
            _configs = Services.Get<ConfigsService>();
            _events = Services.Get<EventsMediator>();
            _sceneRefs = Services.Get<SceneRefs>();
        }

        public bool InRageMode => 
            RageValue >= _configs.RageTreshholdValue;

        public bool IsOpponentPunchingBag => 
            CurrentOpponentGO?.name.Contains("PunchingBag") ?? false;

        public bool IsNextOpponentBoss => 
            SavableData.OpponentLevel % 5 == 0 && SavableData.OpponentLevel != 0;

        public bool IsPreviousOpponentBoss =>
            (SavableData.OpponentLevel - 1) % 5 == 0;

        public Coroutine CurrentDelayRoutine;

        public int GetStatValue(StatType type, CharacterType characterType) =>
            GetStatLevel(type, characterType) 
            * _configs.StatPerLevel
            + _configs.StatsStartValue;

        public CharacterStats GetStats(CharacterType type) => 
            type == CharacterType.Player 
                ? SavableData.Player 
                : SavableData.Opponent;

        public int GetStatLevel(StatType type, CharacterType characterType) => 
            GetStatData(type, characterType).Level;

        public StatData GetStatData(StatType type, CharacterType characterType) => 
            GetStats(characterType).Stats.Find(x => x.StatType == type);

        public int GetUpgradePrice(StatType type) =>
            GetStatLevel(type, CharacterType.Player)
            * _configs.PriceIncreasePerLevel
            + _configs.StartPrice;

        public int GetHealth(CharacterType characterType) =>
            GetStats(characterType).CurrentHealth;

        public int GetMaxHealth(CharacterType characterType) =>
            GetStatValue(StatType.Strength, characterType) * _configs.HealthPerStrength;

        public float GetStamina(CharacterType characterType) =>
            GetStats(characterType).CurrentStamina;

        public int GetMaxStamina(CharacterType characterType) =>
            GetStatValue(StatType.Stamina, characterType);

        public int GetWinReward() => 
            SavableData.OpponentLevel 
            * _configs.MoneyPerOpponent 
            + _configs.StartMoneyForOpponent;

        public int GetPunchIncome()
        {
            int statValue = GetStatValue(StatType.Income, CharacterType.Player);

            if (InRageMode)
                statValue = (int)(statValue * _configs.RageIncomeCoefficient);

            return statValue;
        }

        public Dictionary<StatType,int> CreateRandomAddendStats() =>
            new Dictionary<StatType, int>
            {
                [StatType.Income] = Random.Range(0, _configs.StatIncreaseLevelsByGloves),
                [StatType.Stamina] = Random.Range(0, _configs.StatIncreaseLevelsByGloves),
                [StatType.Strength] = Random.Range(0, _configs.StatIncreaseLevelsByGloves),
            }
                .Where(x => x.Value != 0).ToDictionary(x => x.Key, y => y.Value);

        public void SetGlovesColor(Color color)
        {
            _sceneRefs.PlayerGloves.Create();
            
            SavableData.GlovesColor = color;
            _events.GlovesColorChanged.Invoke();
        }

        public void AddStats(Dictionary<StatType,int> stats)
        {
            foreach (KeyValuePair<StatType, int> pair in stats)
                GetStatData(pair.Key, CharacterType.Player)
                    .With(x => x.Level += pair.Value)
                    .With(x => _events.Upgraded.Invoke(pair.Key));
        }
    }
}