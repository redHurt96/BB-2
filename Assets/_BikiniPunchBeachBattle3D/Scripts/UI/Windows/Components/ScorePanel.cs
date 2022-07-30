using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI.Windows.Components
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private Text _nickname;
        [SerializeField] private Text _score;
        
        private ConfigsService _configs;

        private void Awake() => 
            _configs = Services.Get<ConfigsService>();

        public void AssignPlace(int dataLeaderboardPlace) => 
            _score.text = dataLeaderboardPlace.ToString();

        public void AddPlayerNickname() => 
            _nickname.text = "YOU";

        public void AddRandomNickname() => 
            _nickname.text = _configs.RandomNickName;
    }
}