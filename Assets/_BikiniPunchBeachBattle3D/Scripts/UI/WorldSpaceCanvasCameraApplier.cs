using _BikiniPunchBeachBattle3D.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _BikiniPunchBeachBattle3D.UI
{
    public class WorldSpaceCanvasCameraApplier : MonoBehaviour
    {
        private void Start()
        {
            Camera worldCamera = Services.Get<SceneRefs>().MainCamera;
            GetComponent<Canvas>().worldCamera = worldCamera;
            
            transform.rotation = Quaternion.LookRotation(transform.position - worldCamera.transform.position);
        }
    }
}