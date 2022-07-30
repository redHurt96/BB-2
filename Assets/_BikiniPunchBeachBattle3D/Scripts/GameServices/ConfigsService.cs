using _BikiniPunchBeachBattle3D.UI.Windows.Components;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    [CreateAssetMenu(fileName = "Main configs", menuName = "Game/Main configs", order = 0)]
    public class ConfigsService : ScriptableObject, IService
    {
        public int StatsStartValue = 10;
        public int StatPerLevel = 2;

        [Space] 
        public int StartPrice = 100;
        public int PriceIncreasePerLevel = 50;

        [Space] 
        public int PlayerHealth = 50;
        public int HealthPerLevel = 10;
        public int StaminaPerHit = 2;
        public float RestoreStaminaDelay;
        public float RestoreStaminaSpeed;

        [Space]
        public GameObject PunchingBagPrefab;
        public int PunchingBagHitCount;
        public GraphicsByHealth[] GraphicsByHealth;

        [Space]
        public GameObject FighterOpponentPrefab;
        public GameObject[] OpponentSkins;
        public GameObject BossSkin;
        public float AiPunchDelayMin;
        public float AiPunchDelayMax;
        
        [Space]
        public int MoneyPerOpponent = 100;
        public int StartMoneyForOpponent = 100;

        [Space]
        public int PunchesToRage = 10;
        public float DecreaseRageDelay = .5f;
        public float DecreaseRageSpeed = .3f;
        public float RageIncomeCoefficient = 1.2f;
        public float RageTreshholdValue = .9f;
        
        [Space]
        public GameObject IncomeFxPrefab;

        [Space]
        public float InterstitialAdvDelay;

        [Space]
        public Color DefaultGlovesColor;
        public Color[] GlovesColors;
        public int StatIncreaseLevelsByGloves;
        
        [Space]
        public float WinDelay = 2f;

        [Space]
        public double SweatThreshold = .3f;

        [Space] 
        public int StartPlaceMin = 10000;
        public int StartPlaceMax = 15000;
        public int ShiftPlaceMin = 20;
        public int ShiftPlaceMax = 100;
        public ScorePanel ScorePanelPrefab;
        public string[] RandomNicknames;
        public float ScrollTime = 1f;

        public int RandomPlace => Random.Range(StartPlaceMin, StartPlaceMax);
        public int RandomShift => Random.Range(ShiftPlaceMin, ShiftPlaceMax);

        public string RandomNickName => RandomNicknames[Random.Range(0, RandomNicknames.Length)];
    }
}