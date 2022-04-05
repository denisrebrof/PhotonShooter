using CharacterInput.data;
using CharacterInput.domain;
using CharacterInput.domain.repositories;
using UnityEngine;
using Zenject;

namespace CharacterInput._di
{
    [CreateAssetMenu(fileName = "Character Input Installer", menuName = "Installers/CharacterInputInstaller", order = 0)]
    public class CharacterInputInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            var inputRepository = FindObjectOfType<CharacterInputSceneRepository>();
            Container.Bind<ICharacterInputRepository>().FromInstance(inputRepository).AsSingle();
            var inputStateRepository = FindObjectOfType<InputStateSceneRepository>();
            Container.Bind<IInputStateRepository>().FromInstance(inputStateRepository).AsSingle();
            Container.Bind<IInputMaskRepository>().To<DefaultInputMaskRepository>().AsSingle();
            //Domain
            Container.Bind<InputSuspendedUseCase>().ToSelf().AsSingle();
            Container.Bind<CharacterInputUseCase>().ToSelf().AsSingle();
        }
    }
}