using RH.Utilities.ServiceLocator;
using System.Collections.Generic;
using _BikiniPunchBeachBattle3D.GameServices;

namespace _Game.GameServices
{
    public class WindowsService : IService
    {
        public BaseWindow TopWindow => _windowsStack.Peek();
        public bool IsAnyWindowShown => _windowsStack.Count > 0;

        private readonly Queue<BaseWindow> _windowsStack = new Queue<BaseWindow>();
        private readonly WindowsFactory _factory;
        
        public WindowsService()
        {
            var canvas = Services.Get<SceneRefs>().WindowsCanvas;
            _factory = new WindowsFactory(canvas);
        }

        public T Show<T>() where T : BaseWindow
        {
            T window = _factory.GetWindow<T>();

            _windowsStack.Enqueue(window);

            if (_windowsStack.Count == 1)
                window.gameObject.SetActive(true);

            return window;
        }

        public void Hide(BaseWindow window)
        {
            _windowsStack.Dequeue();
            
            window.gameObject.SetActive(false);

            if (_windowsStack.Count > 0)
                _windowsStack.Peek()
                    .gameObject.SetActive(true);
        }

        public void HideTopWindow()
        {
            if (!IsAnyWindowShown)
                return;

            Hide(TopWindow);
        }
    }
}