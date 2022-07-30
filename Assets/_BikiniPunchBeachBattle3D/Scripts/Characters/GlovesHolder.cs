using UnityEngine;

namespace _BikiniPunchBeachBattle3D.Characters
{
    public class GlovesHolder : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gloves;

        public void Create()
        {
            foreach (GameObject glove in _gloves) 
                glove.SetActive(true);
        }
    }
}