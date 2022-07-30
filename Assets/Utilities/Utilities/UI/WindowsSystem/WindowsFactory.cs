using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.GameServices
{
    public class WindowsFactory
    {
        private const string WINDOWS_FOLDER_NAME = "Windows";

        private readonly Transform _canvas;
        private readonly Dictionary<Type, BaseWindow> _allWindows = new Dictionary<Type, BaseWindow>();
        private readonly Dictionary<Type, BaseWindow> _createdWindows = new Dictionary<Type, BaseWindow>();
        
        public WindowsFactory(Transform canvas)
        {
            _canvas = canvas;
            
            _allWindows = Resources
                .LoadAll<BaseWindow>(WINDOWS_FOLDER_NAME)
                .ToDictionary(x => x.GetType(), y => y);
        }

        public T GetWindow<T>() where T : BaseWindow
        {
            if (_createdWindows.ContainsKey(typeof(T)))
                return (T) _createdWindows[typeof(T)];
            
            if (_allWindows.ContainsKey(typeof(T)))
                return CreateWindow<T>();

            throw new Exception($"There is no window with type {typeof(T)}. Check resources folder");
        }

        private T CreateWindow<T>() where T : BaseWindow
        {
            var origin = _allWindows[typeof(T)];
            origin.gameObject.SetActive(false);
            
            BaseWindow windowInstance = Object.Instantiate(origin, _canvas);
            _createdWindows[typeof(T)] = windowInstance;

            return (T)windowInstance;
        }
    }
}