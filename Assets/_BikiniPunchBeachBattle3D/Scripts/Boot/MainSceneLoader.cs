using UnityEngine;
using UnityEngine.SceneManagement;

namespace _BikiniPunchBeachBattle3D.Boot
{
    public class MainSceneLoader : MonoBehaviour
    {
        private void Start()
        {
            var scene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            scene.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation _)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            SceneManager.UnloadSceneAsync(0);
        }
    }
}