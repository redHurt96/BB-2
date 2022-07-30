using System;
using UnityEngine;

namespace RH.Utilities.Saving
{
    public static class SavableDataExtensions
    {
        public static void Save(this ISavableData savableData)
        {
            string rawData = JsonUtility.ToJson(savableData);

            PlayerPrefs.SetString(savableData.Key, rawData);
            PlayerPrefs.Save();
        }

        public static void LoadIfExist(this ISavableData savableData)
        {
            if (HasSave(savableData))
                Load(savableData);
        }

        public static void Clear(this ISavableData savableData)
        {
            PlayerPrefs.DeleteKey(savableData.Key);
            PlayerPrefs.Save();
        }

        private static void Load<T>(this T savableData) where T : ISavableData
        {
            string rawData = PlayerPrefs.GetString(savableData.Key);
            JsonUtility.FromJsonOverwrite(rawData, savableData);
        }

        private static bool HasSave(this ISavableData savableData) =>
            PlayerPrefs.HasKey(savableData.Key);
    }
}