using Ammo.data;
using Ammo.domain;
using UnityEngine;
using Zenject;

namespace Ammo._di
{
    [CreateAssetMenu(fileName = "AmmoBaseInstaller",menuName = "Installers/AmmoBaseInstaller")]
    public class AmmoBaseInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IAmmoRepository>().To<AmmoInMemoryRepository>().AsSingle();
            Container.Bind<IAmmoStateRepository>().To<AmmoStateInMemoryRepository>().AsSingle();
            //Domain
            Container.Bind<AmmoAvailableStateUseCase>().ToSelf().AsSingle();
            Container.Bind<GetReloadingStateUseCase>().ToSelf().AsSingle();
            Container.Bind<GetReloadRequiredStateUseCase>().ToSelf().AsSingle();
            Container.Bind<PassAmmoUseCase>().ToSelf().AsSingle();
            Container.Bind<ReloadAmmoUseCase>().ToSelf().AsSingle();
        }
    }
}