using _BikiniPunchBeachBattle3D.GameServices;
using _Game.Data;
using RH.Utilities.ServiceLocator;

namespace RH.Utilities.PseudoEcs
{
    public abstract class BaseUpdateSystem : IInitSystem, IUpdateSystem, IDisposeSystem
    {
        protected readonly EventsMediator _events;
        protected readonly SceneRefs _sceneRefs;
        protected readonly ConfigsService _configs;
        protected readonly DataService _data;

        protected BaseUpdateSystem()
        {
            _events = Services.Get<EventsMediator>();
            _sceneRefs = Services.Get<SceneRefs>();
            _configs = Services.Get<ConfigsService>();
            _data = Services.Get<DataService>();
        }
        
        public abstract void Update();

        public virtual void Init() {}
        public virtual void Dispose() {}
    }
}