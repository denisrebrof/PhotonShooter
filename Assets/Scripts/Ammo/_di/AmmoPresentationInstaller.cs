using Ammo.presentation;
using UnityEngine;
using Weapons.presentation;
using Zenject;

namespace Ammo._di
{
    public class AmmoPresentationInstaller : MonoInstaller
    {
        [SerializeField] private AnimatorReloadHandler animatorReloadHandler;

        public override void InstallBindings()
        {
            Container.Bind<IReloadHandler>().FromInstance(animatorReloadHandler).AsSingle();
            Container.Bind<AnimatorReloadHandler>().ToSelf().AsSingle();
            Container.Bind<ReloadingNavigator>().ToSelf().AsSingle();

            Container
                .Bind<WeaponSelectionController.IWeaponSelectionAvailableProvider>()
                .To<ReloadingWeaponSelectionAvailableProvider>().AsSingle();
        }
    }
}