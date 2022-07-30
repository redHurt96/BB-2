using System.Collections;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI.Windows.Components
{
    public class LeaderBoardPanel : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Transform _panelsParent;
        
        private DataService _data;
        private ConfigsService _configs;
        private Coroutine _scrollRoutine;

        private void Awake() => AssignStartPlace();
        private void OnEnable() => Run();

        private void OnDisable() => 
            CoroutineLauncher.Stop(_scrollRoutine);

        private void AssignStartPlace()
        {            
            _data = Services.Get<DataService>();
            _configs = Services.Get<ConfigsService>();

            _data.LeaderboardPlace = _configs.RandomPlace;
        }

        private void Run()
        {
            foreach (Transform child in _panelsParent) 
                Destroy(child.gameObject);

            int currentShift = Mathf.Min(_data.LeaderboardPlace, _configs.RandomShift);
            int panelsCount = currentShift + 5;

            for (int i = 0; i < panelsCount; i++)
            {
                ScorePanel panel = Instantiate(_configs.ScorePanelPrefab, _panelsParent);
                
                panel.AssignPlace(_data.LeaderboardPlace - currentShift + i);

                if (i == 1)
                    panel.AddPlayerNickname();
                else
                    panel.AddRandomNickname();
            }

            _scrollRoutine = CoroutineLauncher.Start(Scroll());
            _data.LeaderboardPlace -= currentShift;
        }

        private IEnumerator Scroll()
        {
            yield return 1f;

            _scrollRect.verticalNormalizedPosition = 0f;

            float scrollTime = 0f;
            
            while (_scrollRect.verticalNormalizedPosition < .98f)
            {
                _scrollRect.verticalNormalizedPosition = Mathf.Lerp(0f, 1f, scrollTime / _configs.ScrollTime);
                scrollTime += Time.deltaTime;

                yield return null;
            }
        }
    }
}