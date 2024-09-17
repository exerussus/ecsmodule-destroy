
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Destroy
{
    public class DestroyPooler : IGroupPooler
    {
        public void Initialize(EcsWorld world)
        {
            BeforeDestroyAction = new PoolerModule<DestroyData.BeforeDestroyAction>(world);
            AfterDyeAction = new PoolerModule<DestroyData.AfterDyeAction>(world);
        }

        public PoolerModule<DestroyData.BeforeDestroyAction> BeforeDestroyAction;
        public PoolerModule<DestroyData.AfterDyeAction> AfterDyeAction;
    }
}