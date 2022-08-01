using System;
using RH.Utilities.Saving;
using UnityEngine;

namespace _Game.Data
{
    [Serializable]
    public class SavableData : ISavableData
    {
        public string Key => "Save";
        
        public string OpponentSkinName;
        public Color GlovesColor;
        public int OpponentLevel = 1;
        public int MoneyAmount;
        public CharacterStats Player = new CharacterStats();
        [NonSerialized] public CharacterStats Opponent = new CharacterStats();
    }
}