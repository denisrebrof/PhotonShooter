using Ammo.presentation;
using Ammo.presentation.handler;
using UnityEngine;
using Weapons.presentation;
using Zenject;

namespace Ammo._di
{
    public class AmmoPresentationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ReloadingNavigator>().ToSelf().AsSingle();

            Container
                .Bind<WeaponSelectionController.IWeaponSelectionAvailableProvider>()
                .To<ReloadingWeaponSelectionAvailableProvider>().AsSingle();
        }
    }
}