using _BikiniPunchBeachBattle3D.Characters;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.GameServices
{
    public class SceneRefs : MonoBehaviour, IService
    {
        public Camera MainCamera;
        public Transform OpponentAnchor;
        public Transform WindowsCanvas;
        //public MaxAdsManager MaxAdsManager;
        public GlovesHolder PlayerGloves;
        public GlovesForOffer GlovesForOffer;
    }
}