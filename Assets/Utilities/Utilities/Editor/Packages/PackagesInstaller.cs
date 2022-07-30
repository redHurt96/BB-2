namespace RH.Utilities.Editor.Packages
{
    internal static class PackagesInstaller
    {
        internal static void InstallCinemachine() =>
            InstallUnityPackage("cinemachine");
        
        internal static void InstallRecorder() =>
            InstallUnityPackage("recorder");

        private static void InstallUnityPackage(string name) => 
            UnityEditor.PackageManager.Client.Add($"com.unity.{name}");
    }
}