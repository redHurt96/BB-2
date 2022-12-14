using UnityEngine.EventSystems;
using UnityEngine;

namespace RH.Utilities.Extensions
{
    public static class EventSystemExtensions
    {
        public static bool IsOverUi(this EventSystem eventSystem)
        {
#if UNITY_EDITOR || UNITY_WEBGL
            return eventSystem.IsPointerOverGameObject();
#else
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
        }
    }
}