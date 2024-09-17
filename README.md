Модуль для 1EasyEcs.   
Обеспечивает удаление сущностей при получении HealthData.DeadMark.   
Время задержки перед уничтожением задается в Settings.DestroyTimeDelay.   
Существует дата, которую можно добавлять к сущности для вызова действия сразу после смерти и перед уничтожением.

````csharp
        
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
````

Зависимости:  
[Ecs-Lite](https://github.com/Leopotam/ecslite.git)  
[1EasyEcs](https://github.com/exerussus/1EasyEcs.git)   


Модули для подключения:  
[Health](https://github.com/exerussus/ecsmodule-health.git) 