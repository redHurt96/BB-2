using System.Collections;
using RH.Utilities.Coroutines;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Systems
{
    public class InterstitialAdvSystem : BaseInitSystem
    {
        private WaitForSeconds _delay;
        private WaitForSeconds _waitForFightEndingDelay;
        
        private Coroutine _waitRoutine;

        private MaxAdsManager _maxAdsManager;
        
        public InterstitialAdvSystem() => 
            _maxAdsManager = Services.Get<MaxAdsManager>();

        public override void Init()
        {
            _delay = new WaitForSeconds(_configs.InterstitialAdvDelay);
            _waitForFightEndingDelay = new WaitForSeconds(1f);
            
            ShowAdvAfterDelay();

            _events.RewardedShown.AddListener(ShowAdvAfterDelay);
        }

        public override void Dispose() => 
            _events.RewardedShown.RemoveListener(ShowAdvAfterDelay);

        private void ShowAdvAfterDelay()
        {
            if (_waitRoutine != null)
            {
                CoroutineLauncher.Stop(_waitRoutine);
                _waitRoutine = null;
            }
            
            _waitRoutine = CoroutineLauncher.Start(ShowAdv());
        }

        private IEnumerator ShowAdv()
        {
            yield return _delay;

            while (!_data.IsOpponentPunchingBag)
                yield return _waitForFightEndingDelay;
            
            _maxAdsManager.ShowInter("Main scene");
        }
    }
}