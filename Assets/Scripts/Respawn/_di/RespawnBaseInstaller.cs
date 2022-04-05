﻿using Respawn.data;
using Respawn.domain;
using Respawn.domain.repositories;
using Respawn.presentation;
using Respawn.presentation.Spawner;
using UnityEngine;
using Zenject;

namespace Respawn._di
{
    [CreateAssetMenu(menuName = "Installers/RespawnBaseInstaller")]
    public class RespawnBaseInstaller : ScriptableObjectInstaller
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
            Container
                .Bind<ICurrentPlayerSpawnEventRepository>()
                .To<СurrentPlayerSpawnEventInMemoryRepository>()
                .AsSingle();
            //Domain
            Container.Bind<SpawnPointAvailableUseCase>().ToSelf().AsSingle();
            Container.Bind<SpawnCurrentPlayerAvailableUseCase>().ToSelf().AsSingle();
            Container.Bind<SpawnCurrentPlayerUseCase>().ToSelf().AsSingle();
            Container.Bind<RandomOrFirstAvailableSpawnPointUseCase>().ToSelf().AsSingle();
            //Presentation
            var positionNavigator = FindObjectOfType<SimpleSpawnPoints>();
            Container.Bind<ISpawnPositionNavigator>().FromInstance(positionNavigator).AsSingle();
        }
    }
}