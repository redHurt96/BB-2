﻿using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;

namespace RH.Utilities.Editor.Setup
{
    internal static class DirectoryCreator
    {
        private static readonly string[] s_foldersNames;

        static DirectoryCreator()
        {
            s_foldersNames = new[] {
                "_Settings",
                "Materials",
                "Models",
                "Prefabs",
                "Scenes",
                "Scripts",
                "Scripts/Common",
                "Scripts/Logic",
                "Scripts/Logic/Systems",
                "Scripts/Logic/Services",
                "Sprites",
            };
        }

        internal static void CreateDefaultFolders()
        {
            string path = Combine(dataPath, $"_{productName}");

            CreateDirectory(path);
            CreateSubFolders(path);

            AssetDatabase.Refresh();
        }

        private static void CreateSubFolders(string rootPath)
        {
            foreach (string name in s_foldersNames)
                CreateDirectory(Combine(rootPath, name));
        }
    }
}