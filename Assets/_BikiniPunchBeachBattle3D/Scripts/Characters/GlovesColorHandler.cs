using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Characters
{
    public class GlovesColorHandler : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private DataService _data;
        private EventsMediator _events;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();

            ChangeColor();
            
            _events.GlovesColorChanged.AddListener(ChangeColor);
        }

        private void ChangeColor() => 
            _meshRenderer.material.color = _data.SavableData.GlovesColor;
    }
}