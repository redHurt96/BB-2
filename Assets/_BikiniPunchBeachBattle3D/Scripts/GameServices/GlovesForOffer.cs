using UnityEngine;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class GlovesForOffer : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MeshRenderer[] _meshRenderers;

        public void SetColor(Color color)
        {
            _camera.gameObject.SetActive(true);

            foreach (MeshRenderer meshRenderer in _meshRenderers) 
                meshRenderer.material.color = color;
        }

        public void Disable() => 
            _camera.gameObject.SetActive(false);
    }
}