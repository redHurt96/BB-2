using UnityEngine;

namespace RH.Utilities.SingletonAccess
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Instance;

        public void CreateInstance() => 
            Instance = this as T;

        public void DestroyInstance() => 
            Instance = null;
    }
}