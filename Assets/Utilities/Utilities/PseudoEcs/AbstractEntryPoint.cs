using System;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace RH.Utilities.PseudoEcs
{
    public abstract class AbstractEntryPoint : MonoBehaviour
    {
        protected SystemsArray _systems { get; private set; }
        protected Services _services { get; private set; }

        private void Awake()
        {
            Application.targetFrameRate = 60;

            PrepareServices();
            PrepareSystems();
        }

        private void Update() => 
            _systems.Update();

        private void OnDestroy()
        {
            _systems.Dispose();
            Services.DestroyInstance();
        }

        private void PrepareSystems()
        {
            _systems = new SystemsArray();
            RegisterSystems();
            _systems.Init();
        }

        private void PrepareServices()
        {
            _services = new Services();
            RegisterServices();
        }

        protected abstract void RegisterServices();
        protected abstract void RegisterSystems();
    }
}