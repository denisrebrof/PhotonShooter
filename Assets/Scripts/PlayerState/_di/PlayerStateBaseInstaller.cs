using PlayerState.data;
using PlayerState.domain;
using PlayerState.domain.repositories;
using UnityEngine;
using Zenject;

namespace PlayerState._di
{
    [CreateAssetMenu(menuName = "Installers/PlayerStateBaseInstaller")]
    public class PlayerStateBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container
                .Bind<IPlayerLifecycleEventRepository>()
                .To<PlayerLifecycleEventInMemoryRepository>()
                .AsSingle();
            
            var stateRepository = FindObjectOfType<PlayerStateSceneRepository>();
            Container
                .Bind<IPlayerStateRepository>()
                .FromInstance(stateRepository)
                .AsSingle();
            
            //Domain
            Container.Bind<PlayerStateUpdatesUseCase>().ToSelf().AsSingle();
        }
    }
}