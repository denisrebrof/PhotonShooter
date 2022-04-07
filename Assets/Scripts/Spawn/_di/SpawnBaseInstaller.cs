using Spawn.data;
using Spawn.domain;
using Spawn.domain.repositories;
using Spawn.presentation.Spawner;
using UnityEngine;
using Zenject;

namespace Spawn._di
{
    [CreateAssetMenu(menuName = "Installers/SpawnBaseInstaller")]
    public class SpawnBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container
                .Bind<ICurrentPlayerSpawnEventRepository>()
                .To<СurrentPlayerSpawnEventInMemoryRepository>()
                .AsSingle();
            //Domain
            Container.Bind<SpawnPlayerAvailableUseCase>().ToSelf().AsSingle();
            Container.Bind<SpawnCurrentPlayerUseCase>().ToSelf().AsSingle();
            Container.Bind<ReadyAfterDeathCommandUseCase>().ToSelf().AsSingle();
        }
    }
}