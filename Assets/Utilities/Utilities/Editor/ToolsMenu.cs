using RH.Utilities.Editor.Packages;
using RH.Utilities.Editor.SimpleCi;
using UnityEditor;
using static RH.Utilities.Editor.ToolsMenuNames;

namespace RH.Utilities.Editor
{
    public static class ToolsMenu
    {
        //TODO: Fix, now it's create problems with urp after replace
        // [MenuItem(TOOLS + "/" + SETUP + "/📄 Replace manifest")]
        // private static void ReplaceManifest() => ManifestUpdater.LoadNewManifest();

        // [MenuItem(TOOLS + "/" + SETUP + "/📁 Create default folders")]
        // private static void CreateDefaultFolders() => DirectoryCreator.CreateDefaultFolders();

        [MenuItem(TOOLS + "/" + BUILD + "/📁 Show build folder")]
        private static void OpenBuildsFolder() => Builder.OpenBuildsFolder();

        [MenuItem(TOOLS + "/" + BUILD + "/Android")]
        private static void BuildAndroid() => Builder.ToAndroid();

        [MenuItem(TOOLS + "/" + ADD_PACKAGES + "/🎥 Cinemachine")]
        private static void InstallCinemachine() => PackagesInstaller.InstallCinemachine();
        
        [MenuItem(TOOLS + "/" + ADD_PACKAGES + "/🎥 Recorder")]
        private static void InstallRecorder() => PackagesInstaller.InstallRecorder();
    }
}