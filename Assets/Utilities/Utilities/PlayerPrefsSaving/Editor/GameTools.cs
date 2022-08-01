using _BikiniPunchBeachBattle3D.GameServices;
using _Game.Data;
using UnityEditor;
using UnityEngine;

namespace RH.Utilities.Saving
{
    public static class GameTools
    {
        [MenuItem("🎮 Game/💾 Clear saved data %#t")]
        public static void ClearAll()
        {
            Debug.Log($"Saved data was cleared");
            new SavableData().Clear();
        }

        [MenuItem("🎮 Game/⚙ Select configs %#d")]
        public static void SelectSettings()
        {
            var path = AssetDatabase.GetAssetPath(Resources.Load<ConfigsService>("Main configs"));
            var asset = AssetDatabase.LoadAssetAtPath<ConfigsService>(path);
            Selection.activeObject = asset;
        }
    }
}