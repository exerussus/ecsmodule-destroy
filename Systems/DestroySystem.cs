using ECS.Modules.Exerussus.Health;
using Exerussus._1EasyEcs.Scripts.Core;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Destroy.Systems
{
    public class DestroySystem : EasySystem<DestroyPooler>
    {
        public DestroySystem(DestroySettings settings)
        {
            _settings = settings;
        }

        private readonly DestroySettings _settings;
        private EcsFilter _destroyFilter;
        private EcsFilter _initDestroyFilter;
        private EcsPool<ReadOnlyDestroyData.DestroyProcess> _destroyProcessPool;
        
        protected override void Initialize()
        {
            _destroyProcessPool = World.GetPool<ReadOnlyDestroyData.DestroyProcess>();
            _destroyFilter = World.Filter<ReadOnlyDestroyData.DestroyProcess>().End();
            _initDestroyFilter = World.Filter<HealthData.DeadMark>().Exc<ReadOnlyDestroyData.DestroyProcess>().End();
        }

        protected override void Update()
        {
            foreach (var entity in _initDestroyFilter)
            {
                if (Pooler.AfterDyeAction.Has(entity))
                {
                    ref var afterDyeActionData = ref Pooler.AfterDyeAction.Get(entity);
                    afterDyeActionData.Value.Invoke(entity);
                }
                
                ref var initDestroyData = ref _destroyProcessPool.Add(entity);
                initDestroyData.TimeRemaining = _settings.DestroyTimeDelay;
            }
            
            foreach (var entity in _destroyFilter)
            {
                ref var destroyProcessData = ref _destroyProcessPool.Get(entity);
                destroyProcessData.TimeRemaining -= DeltaTime;
                
                if (destroyProcessData.TimeRemaining > 0) continue;

                if (Pooler.BeforeDestroyAction.Has(entity))
                {
                    ref var beforeDestroyActionData = ref Pooler.BeforeDestroyAction.Get(entity);
                    beforeDestroyActionData.Value.Invoke(entity);
                }
                
                World.DelEntity(entity);
            }
        }
    }
}