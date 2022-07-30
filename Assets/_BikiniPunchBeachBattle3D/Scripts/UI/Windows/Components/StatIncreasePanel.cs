using System.Collections.Generic;
using _BikiniPunchBeachBattle3D.GameServices;
using _BikiniPunchBeachBattle3D.Scripts.Domain;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _BikiniPunchBeachBattle3D.UI.Windows.Components
{
    public class StatIncreasePanel : MonoBehaviour
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _percent;
        
        private ConfigsService _configs;

        public void Setup(KeyValuePair<StatType,int> stat)
        {
            _configs ??= Services.Get<ConfigsService>();
            
            gameObject.SetActive(true);

            _title.text = stat.Key.ToString().ToUpper();
            _percent.text = $"+{stat.Value * _configs.StatPerLevel}";                
        }

        public void Hide() => 
            gameObject.SetActive(false);
    }
}