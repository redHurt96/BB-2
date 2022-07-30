using System;
using System.Collections.Generic;
using _BikiniPunchBeachBattle3D.Scripts.Domain;

namespace _Game.Data
{
    [Serializable]
    public class CharacterStats
    {
        public int CurrentHealth;
        public int MaxHealth;

        public float CurrentStamina;
        
        public List<StatData> Stats = new List<StatData>()
        {
            new StatData {StatType = StatType.Strength, Level = 0},
            new StatData {StatType = StatType.Income, Level = 0},
            new StatData {StatType = StatType.Stamina, Level = 0},
        };
        
        public StatData GetStat(StatType type) => 
            Stats.Find(x => x.StatType == type);
    }
}