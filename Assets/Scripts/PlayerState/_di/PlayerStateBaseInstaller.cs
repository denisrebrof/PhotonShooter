using PlayerState.data;
using PlayerState.domain;
using PlayerState.domain.repositories;
using UnityEngine;
using Zenject;

namespace PlayerState._di
{
    [CreateAssetMenu(menuName = "Installers/PlayerStateBaseInstaller")]
    public class PlayerStateBaseInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container
                .Bind<ICurrentPlayerLifecycleEventRepository>()
                .To<CurrentPlayerLifecycleEventInMemoryRepository>()
                .AsSingle();
            Container
                .Bind<ICurrentPlayerStateRepository>()
                .To<CurrentPlayerStateInMemoryRepository>()
                .AsSingle();
            //Domain
            Container.Bind<CurrentPlayerStateUpdatesUseCase>().ToSelf().AsSingle();
            Container.Bind<PlayerLifecycleEventUseCase>().ToSelf().AsSingle();
        }
    }
}