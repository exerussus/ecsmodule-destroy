using ECS.Modules.Exerussus.Destroy.Systems;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Destroy
{
    public class DestroyGroup : EcsGroup<DestroyPooler>
    {
        public DestroySettings Settings;
        protected override void SetFixedUpdateSystems(IEcsSystems fixedUpdateSystems)
        {
            fixedUpdateSystems.Add(new DestroySystem(Settings));
        }
        
        public DestroyGroup SetDestroyTimeDelay(float destroyTimeDelay)
        {
            Settings.DestroyTimeDelay = destroyTimeDelay;
            return this;
        }
    }
}