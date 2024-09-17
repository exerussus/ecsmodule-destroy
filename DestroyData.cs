using System;
using Exerussus._1EasyEcs.Scripts.Core;

namespace ECS.Modules.Exerussus.Destroy
{
    public static class DestroyData
    {
        /// <summary> Вызывает Action сразу после получения DeadMark в системе DamageDealer и HealthRegeneration.
        /// Работает только при включенном HasDestroySystem в HealthSettings.</summary>
        public struct AfterDyeAction : IEcsComponent
        {
            public Action<int> Value; 
        }
        
        /// <summary> Вызывает Action прямо перед уничтожением Entity. НЕ удаляйте Entity в этом Action.
        /// Работает только при включенном HasDestroySystem в HealthSettings.</summary>
        public struct BeforeDestroyAction : IEcsComponent
        {
            public Action<int> Value; 
        }
    }
}