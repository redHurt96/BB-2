using System.Collections.Generic;

namespace RH.Utilities.PseudoEcs
{
    public class SystemsArray
    {
        private List<IInitSystem> _initSystems = new List<IInitSystem>();
        private List<IDisposeSystem> _disposeSystems = new List<IDisposeSystem>();
        private List<IUpdateSystem> _updateSystems = new List<IUpdateSystem>();

        public SystemsArray Add(params ISystem[] systems)
        {
            foreach (ISystem system in systems)
                Add(system);

            return this;
        }
        
        public SystemsArray Add(ISystem system)
        {
            if (system is IInitSystem initSystem)
                _initSystems.Add(initSystem);
            if (system is IDisposeSystem disposeSystem)
                _disposeSystems.Add(disposeSystem);
            if (system is IUpdateSystem updateSystem)
                _updateSystems.Add(updateSystem);

            return this;
        }

        public SystemsArray Init()
        {
            _initSystems?.ForEach(x => x.Init());
            return this;
        }

        public void Update() => 
            _updateSystems?.ForEach(x => x.Update());

        public void Dispose() => 
            _disposeSystems?.ForEach(x => x.Dispose());
    }
}