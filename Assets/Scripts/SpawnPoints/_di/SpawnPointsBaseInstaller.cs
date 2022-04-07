using Spawn.presentation.Spawner;
using SpawnPoints.data;
using SpawnPoints.domain;
using SpawnPoints.domain.repositories;
using SpawnPoints.presentation;
using UnityEngine;
using Zenject;

namespace SpawnPoints._di
{
    [CreateAssetMenu(fileName = "SpawnPointsBaseInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public class SpawnPointsBaseInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container
                .Bind<ISpawnPointRepository>()
                .To<SpawnPointInMemoryRepository>()
                .AsSingle();
            Container
                .Bind<ISpawnPointCooldownRepository>()
                .To<SpawnPointCooldownSceneRepository>()
                .FromNewComponentOnNewGameObject().AsSingle();
            //Domain
            Container.Bind<SpawnPointAvailableUseCase>().ToSelf().AsSingle();
            Container.Bind<RandomOrFirstAvailableSpawnPointUseCase>().ToSelf().AsSingle();
            //Presentation
            var positionNavigator = FindObjectOfType<SimpleSpawnPoints>();
            Container.Bind<ISpawnPositionNavigator>().FromInstance(positionNavigator).AsSingle();
        }
    }
}