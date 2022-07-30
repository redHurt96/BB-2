using System.Collections;
using UnityEngine;

namespace RH.Utilities.Coroutines
{
    public static class CoroutineLauncher
    {
        private static CoroutinesLauncherReceiver Receiver
        {
            get
            {
                if (_receiver == null && Application.isPlaying)
                {
                    _receiver = new GameObject("CoroutinesLauncher", typeof(CoroutinesLauncherReceiver))
                        .GetComponent<CoroutinesLauncherReceiver>();
                }

                return _receiver;
            }
        }

        private static CoroutinesLauncherReceiver _receiver;

        public static Coroutine Start(IEnumerator coroutine) => Receiver.StartCoroutine(coroutine);

        public static void Stop(IEnumerator coroutine)
        {
            if (_receiver != null)
                _receiver.StopCoroutine(coroutine);
        }

        public static void Stop(Coroutine coroutine)
        {
            if (_receiver != null)
                _receiver.StopCoroutine(coroutine);
        }

        public static void StopAll() => Receiver.StopAllCoroutines();

        public static bool Exist => _receiver != null;

        private class CoroutinesLauncherReceiver : MonoBehaviour
        {
            private void OnDestroy()
            {
                if (this != null)
                    StopAllCoroutines();
            }
        }
    }
}