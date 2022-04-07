using PlayerInput.data;
using PlayerInput.domain;
using PlayerInput.domain.repositories;
using UnityEngine;
using Zenject;

namespace PlayerInput._di
{
    [CreateAssetMenu(fileName = "Player Input Installer", menuName = "Installers/Player Input Installer", order = 0)]
    public class PlayerInputInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            var inputRepository = FindObjectOfType<PlayerInputSceneRepository>();
            Container.Bind<IPlayerInputRepository>().FromInstance(inputRepository).AsSingle();
            var inputStateRepository = FindObjectOfType<InputStateSceneRepository>();
            Container.Bind<IInputStateRepository>().FromInstance(inputStateRepository).AsSingle();
            Container.Bind<IInputMaskRepository>().To<DefaultInputMaskRepository>().AsSingle();
            //Domain
            Container.Bind<PlayerInputSuspendedUseCase>().ToSelf().AsSingle();
            Container.Bind<PlayerInputUseCase>().ToSelf().AsSingle();
        }
    }
}