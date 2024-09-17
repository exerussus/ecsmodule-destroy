
using Exerussus._1EasyEcs.Scripts.Core;

namespace ECS.Modules.Exerussus.Destroy
{
    public static class ReadOnlyDestroyData
    {
        /// <summary> Имеет таймер уничтожения сущности. При 0 - уничтожает сущность. </summary>
        public struct DestroyProcess : IEcsComponent
        {
            public float TimeRemaining;
        }
    }
}