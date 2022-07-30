using _BikiniPunchBeachBattle3D.Characters;
using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Effects
{
    public class SkinColorByStaminaInteractor : MonoBehaviour
    {
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private SkinnedMeshRenderer _meshRenderer;
        [SerializeField] private int _materialIndex;

        [SerializeField] private Color _origin;
        [SerializeField] private Color _tired;
        
        private DataService _data;
        private EventsMediator _events;

        private void Start()
        {
            _data = Services.Get<DataService>();
            _events = Services.Get<EventsMediator>();
            
            _events.StaminaAmountChanged.AddListener(ChangeColor);
        }

        private void OnDestroy() => 
            _events.StaminaAmountChanged.RemoveListener(ChangeColor);

        private void ChangeColor(CharacterType type, float arg1)
        {
            if (type != _characterType)
                return;

            _meshRenderer.materials[_materialIndex].color =
                Color.Lerp(_tired, _origin, _data.GetStamina(type) / _data.GetMaxStamina(type));
        }
    }
}