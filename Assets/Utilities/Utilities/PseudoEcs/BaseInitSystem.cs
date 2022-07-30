using _BikiniPunchBeachBattle3D.GameServices;
using _Game.Data;
using RH.Utilities.ServiceLocator;

namespace RH.Utilities.PseudoEcs
{
    public abstract class BaseInitSystem : IInitSystem, IDisposeSystem
    {
        protected readonly EventsMediator _events;
        protected readonly SceneRefs _sceneRefs;
        protected readonly ConfigsService _configs;
        protected readonly DataService _data;
        protected readonly ActionsMediator _actions;

        protected BaseInitSystem()
        {
            _events = Services.Get<EventsMediator>();
            _sceneRefs = Services.Get<SceneRefs>();
            _configs = Services.Get<ConfigsService>();
            _data = Services.Get<DataService>();
            _actions = Services.Get<ActionsMediator>();
        }

        public abstract void Init();
        public abstract void Dispose();
    }
}