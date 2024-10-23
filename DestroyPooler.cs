
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
            AfterDieAction = new PoolerModule<DestroyData.AfterDieAction>(world);
        }

        public PoolerModule<DestroyData.BeforeDestroyAction> BeforeDestroyAction;
        public PoolerModule<DestroyData.AfterDieAction> AfterDieAction;
    }
}