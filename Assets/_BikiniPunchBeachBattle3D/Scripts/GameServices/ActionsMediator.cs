using System.Collections;
using System.Threading.Tasks;
using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using _BikiniPunchBeachBattle3D.UI.Windows;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class ActionsMediator : IService
    {
        private readonly Wallet _wallet;
        private readonly ConfigsService _configs;
        private readonly DataService _data;
        private readonly EventsMediator _events;
        private readonly SceneRefs _sceneRefs;
        private readonly WindowsService _windows;

        public ActionsMediator()
        {
            _wallet = Services.Get<Wallet>();
            _configs = Services.Get<ConfigsService>();
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            _sceneRefs = Services.Get<SceneRefs>();
            _windows = Services.Get<WindowsService>();
        }

        public void BuyUpgrade(StatType statType)
        {
            int upgradePrice = _data.GetUpgradePrice(statType);

            _data.GetStatData(statType, CharacterType.Player).Level++;
            _wallet.Remove(upgradePrice);

            _events.Upgraded.Invoke(statType);
        }

        public void CreatePunchingBag()
        {
            _data.CurrentOpponentGO = Object.Instantiate(
                _configs.PunchingBagPrefab,
                _sceneRefs.OpponentAnchor.position,
                _sceneRefs.OpponentAnchor.rotation);

            _data.SavableData.Opponent = new CharacterStats();
            _data.SavableData.Opponent.MaxHealth =
                _data.GetStatValue(StatType.Strength, CharacterType.Player) * _configs.PunchingBagHitCount;
            
            ResetHealth();
        }

        public void GoToFight()
        {
            DestroyCurrentOpponent();
            CreateFighterOpponent();
        }

        public void DestroyCurrentOpponent() => 
            Object.Destroy(_data.CurrentOpponentGO);

        private void CreateFighterOpponent()
        {
            Debug.Log($"[ActionsMediator] Create opponent: level {_data.SavableData.OpponentLevel}; is boss: {_data.IsNextOpponentBoss}");
            
            _data.CurrentOpponentGO = Object.Instantiate(
                _configs.FighterOpponentPrefab,
                _sceneRefs.OpponentAnchor.position,
                _sceneRefs.OpponentAnchor.rotation);

            _data.SavableData.Opponent = new CharacterStats();

            foreach (StatData statData in _data.SavableData.Opponent.Stats)
                statData.Level = _data.SavableData.OpponentLevel;

            _data.SavableData.Opponent.MaxHealth =
                _data.GetStatValue(StatType.Strength, CharacterType.Opponent)
                * _configs.HealthPerLevel;

            ResetHealth();
            ResetStamina();
        }

        public void ResetHealth()
        {
            _data.SavableData.Player.CurrentHealth = _data.SavableData.Player.MaxHealth;
            _data.SavableData.Opponent.CurrentHealth = _data.SavableData.Opponent.MaxHealth;
            
            _events.HealthAmountChanged.Invoke(CharacterType.Player);
            _events.HealthAmountChanged.Invoke(CharacterType.Opponent);
        }

        public void ResetStamina()
        {
            _data.SavableData.Player.CurrentStamina = _data.GetMaxStamina(CharacterType.Player);
            _data.SavableData.Opponent.CurrentStamina = _data.GetMaxStamina(CharacterType.Opponent);
            
            _events.StaminaAmountChanged.Invoke(CharacterType.Opponent, _data.GetMaxStamina(CharacterType.Opponent));
            _events.StaminaAmountChanged.Invoke(CharacterType.Player, _data.GetMaxStamina(CharacterType.Player));
        }

        public void HitPlayer()
        {
            _data.SavableData.Player.CurrentHealth =
                Mathf.Max(_data.SavableData.Player.CurrentHealth - _data.GetStatValue(StatType.Strength, CharacterType.Opponent),
                    0);
            _events.HealthAmountChanged.Invoke(CharacterType.Player);
            
            _data.SavableData.Opponent.CurrentStamina -= _configs.StaminaPerHit;
            _events.StaminaAmountChanged.Invoke(CharacterType.Opponent, -_configs.StaminaPerHit);

            if (_data.GetHealth(CharacterType.Player) <= 0f)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void HitOpponent()
        {
            _data.SavableData.Opponent.CurrentHealth =
                Mathf.Max(_data.SavableData.Opponent.CurrentHealth - _data.GetStatValue(StatType.Strength, CharacterType.Player),
                    0);
            _events.HealthAmountChanged.Invoke(CharacterType.Opponent);

            _data.SavableData.Player.CurrentStamina -= _configs.StaminaPerHit;
            _events.StaminaAmountChanged.Invoke(CharacterType.Player, -_configs.StaminaPerHit);

            if (_data.GetHealth(CharacterType.Opponent) <= 0f)
            {
                if (!_data.IsOpponentPunchingBag && _data.CurrentDelayRoutine == null)
                    _data.SavableData.OpponentLevel++;

                _data.CurrentDelayRoutine = CoroutineLauncher.Start(InvokeOpponentsDefeatedEvent());
            }
        }

        public void GoToMainHud(bool withOffer)
        {
            _windows.HideTopWindow();

            if (_data.IsPreviousOpponentBoss && withOffer)
                _windows.Show<GlovesOfferWindow>();
            else
                _windows.Show<HudWindow>();
        }

        private IEnumerator InvokeOpponentsDefeatedEvent()
        {
            yield return new WaitForSeconds(_configs.WinDelay);

            _data.CurrentDelayRoutine = null;
            _events.OpponentDefeated.Invoke();
        }
    }
}