using Movement.data;
using Movement.domain;
using UnityEngine;
using Zenject;

namespace Movement._d
{
    [CreateAssetMenu(fileName = "MovementBaseInstaller", menuName = "Installers/MovementBaseInstaller", order = 0)]
    public class MovementBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IMovementStateRepository>().To<MovementStateInMemoryRepository>().AsSingle();
            Container.Bind<IJumpingStateRepository>().To<JumpingStateInMemoryRepository>().AsSingle();
            //Domain
            Container.Bind<CurrentPlayerMovementStateUseCase>().ToSelf().AsSingle();
        }
    }
}